    private void Button_Clicked(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var grid = (Grid)button.Parent;
        var lblUserName = (TextBlock)grid.FindName("lblUserName");
        pageTitle.Text = lblUserName.Text;
    }
