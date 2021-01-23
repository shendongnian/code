    private void geckoWebBrowser1_ShowContextMenu(object sender, GeckoContextMenuEventArgs e)
      {      
       foreach(MenuItem i in e.ContextMenu.MenuItems)      
       {
         if(i.Text == "View in System Browser")
            e.ContextMenu.MenuItems.Remove(i);
       }
    }
