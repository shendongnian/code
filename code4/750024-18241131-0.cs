    private void AddContextMenuWithMenuItems(Button btn)
    {
       ContextMenu contextMenu = new ContextMenu();
       MenuItem menuItem1 = new MenuItem() { Header = "Edit", Tag = "Edit" };
       MenuItem menuItem2 = new MenuItem() { Header = "Remove", Tag = "Remove" };
       menuItem1.Click += new RoutedEventHandler(menuItem1_Click);
       menuItem2.Click += new RoutedEventHandler(menuItem2_Click);
       contextMenu.Items.Add(menuItem1);
       contextMenu.Items.Add(menuItem2);
       // Store the name of the button in the Tag property of the context menu
       contextMenu.Tag = btn.Name;
       ContextMenuService.SetContextMenu(btn, contextMenu);
    } 
