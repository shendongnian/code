    private void TreeView_MouseDoubleClick(object sender, RoutedEventArgs e)
    {
        var menuItem = trvMenu.SelectedItem as MyProject.MenuItem;
        if (menuItem != null)
        {
            MessageBox.Show(menuItem.Title);
        }
    }
