    var tab = new TabItem();
    var stack = new StackPanel() { Orientation = Orientation.Horizontal };
    stack.Children.Add(new Image() { Source = new BitmapImage(new Uri("header.png")) });
    stack.Children.Add(new TextBlock() { Text = "Header" });
    tab.Header = stack;
