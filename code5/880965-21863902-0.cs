    void MenuItemChecked(object sender, RoutedEventArgs e)
    {
       var menuItem = e.OriginalSource as MenuItem;
       
       // Uncheck all other items
       ...
       // Change theme to what the current menu item specifies
       ...
       // Mark the event handled
       e.Handled = true;
    }
