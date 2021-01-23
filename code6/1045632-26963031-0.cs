    var grid = new Grid();
    grid.Margin = new Thickness(0, 26, 0, 0);  // compensate for status bar
    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    var header = new MyHeaderUserControl();
    grid.Children.Add(header);
    Grid.SetRow(rootFrame, 1);
    grid.Children.Add(rootFrame);
    Window.Current.Content = grid;
