    var window = new Window1();
    var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
    Button button = new Button();
    button.Content = "New Button";
    button.Visibility = Visibility.Visible;
    button.Height = 50;
    button.Width = 200;
    stackPanel.Children.Add(button);
    
    window.Content = stackPanel;
    window.Show();
