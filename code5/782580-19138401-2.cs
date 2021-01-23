    var menu = new PopupMenu(this, sender);
    menu.Inflate(Resource.Menu.popupmenu);
    menu.MenuItemClick += (s, a) =>
    {
        switch (a.Item.ItemId)
        {
            case Resource.Menu.pm_update:
                // update stuff
                break;
            case Resource.Menu.pm_delete:
                // delete stuff
                break;
        }
    };
