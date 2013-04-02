﻿/***************************************************************************************

	Copyright 2013 Little Crab Solutions

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		CreateListAction.cs
	Namespace:		Manatee.Trello
	Class Name:		CreateListAction
	Purpose:		Indicates a list was added to a board.

***************************************************************************************/
using Manatee.Json.Extensions;

namespace Manatee.Trello
{
	/// <summary>
	/// Indicates a list was added to a board.
	/// </summary>
	public class CreateListAction : Action
	{
		private Board _board;
		private readonly string _boardId;
		private List _list;
		private readonly string _listId;

		/// <summary>
		/// Gets the board associated with the action.
		/// </summary>
		public Board Board
		{
			get
			{
				VerifyNotExpired();
				return ((_board == null) || (_board.Id != _boardId)) && (Svc != null) ? (_board = Svc.Retrieve<Board>(_boardId)) : _board;
			}
		}
		/// <summary>
		/// Gets the list associated with the action.
		/// </summary>
		public List List
		{
			get
			{
				VerifyNotExpired();
				return ((_list == null) || (_list.Id != _listId)) && (Svc != null) ? (_list = Svc.Retrieve<List>(_listId)) : _list;
			}
		}

		/// <summary>
		/// Creates a new instance of the CreateListAction class.
		/// </summary>
		/// <param name="action">The base action</param>
		public CreateListAction(Action action)
			: base(action.Svc, action.Id)
		{
			_boardId = action.Data.Object.TryGetObject("board").TryGetString("id");
			_listId = action.Data.Object.TryGetObject("list").TryGetString("id");
		}
	}
}