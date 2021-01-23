    for (int i = 1; i <= ItemCount(); i++)
    {
        var menuItem = new MenuItem() { Name = "MenuItem" + i, Header = "Menu Item " + i };
        menuItem.Click += item_Click;
        mnuItem.Items.Add(menuItem);    
    }
    
