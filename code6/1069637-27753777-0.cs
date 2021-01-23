    private void DoStuff(object sender, RoutedEventArgs e)
    {
        // Get the selected MenuItem
        var menuItem = (MenuItem)sender;
        // Get the ContextMenu for the menuItem
        var ctxtMenu = (ContextMenu)menuItem.Parent;
        // Get the placementTarget of the ContextMenu
        var item = (DataGrid)ctxtMenu.PlacementTarget;
        // Now you can get selected item/cell etc.. and cast it to your object
        // example: 
        //var someObject = (SomeObject)item.SelectedCells[0].Item;
        // rest of code....
    }
