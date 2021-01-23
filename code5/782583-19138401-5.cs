    var menu = new PopupMenu(this, (View)sender);
    menu.Inflate(Resource.Menu.popupmenu);
    menu.MenuItemClick += (s, a) =>
    {
        switch (a.Item.ItemId)
        {
            case Resource.Id.pm_update:
                // update stuff
                break;
            case Resource.Id.pm_delete:
                // delete stuff
                break;
        }
    };
