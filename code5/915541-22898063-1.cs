    private void headerLogoutTime_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = sender as MenuItem;
        StringBuilder sb = new StringBuilder();
        if (menuItem != null) 
        {
            headerLogoutTime.Header = "";
            headerLogoutTime.Header = sb.Append("LogOut Time: ").Append(headerLogoutTime.Header).Append(menuItem.Header);
        }
    }
