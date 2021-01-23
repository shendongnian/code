    TabItem tab = new TabItem();
    var stack = new StackPanel() { Orientation = Orientation.Horizontal };
    var textBlock = new TextBlock() { Name = "extra" }
    stack.Children.Add(new TextBlock() { Text = header });
    stack.Children.Add(textBlock);
    tab.Header = stack;
    tabControl.Items.Add(tab);
