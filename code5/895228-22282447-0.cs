    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var panel = new StackPanel();
        var button = new Button();
        button.Width = 75;
        button.Height = 25;
        panel.Children.Add(button);
        panel.Loaded += new RoutedEventHandler(panel_Loaded);
        MainGrid.Children.Add(panel);
    }
    private void panel_Loaded(object sender, RoutedEventArgs e)
    {
        Panel panel = sender as Panel;
        Title = panel.ActualHeight.ToString();
    }
