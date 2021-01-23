    PopupMenu menu = new PopupMenu (this,tvEmail);
			menu.Inflate (Resource.Menu.popup_menu);
			menu.MenuItemClick += (s1, arg1) => {
				switch(arg1.Item.TitleFormatted.ToString())
				{
				case "Edit":
					//Edit action here
					break;
				}
