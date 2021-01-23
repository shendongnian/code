    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        MenuItem menuItem = sender as MenuItem;
        Me.cmb1.Text = menuItem.CommandParameter.ToString();
    }
