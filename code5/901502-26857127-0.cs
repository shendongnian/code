    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        int rows = 2, columns = 3;
        for (int i = 0; i < rows; i++)
        {
            RowDefinition definition = new RowDefinition();
            definition.Height = new GridLength(1, GridUnitType.Star);
            grid.RowDefinitions.Add(definition);
        }
        for (int i = 0; i < columns; i++)
        {
            ColumnDefinition definition = new ColumnDefinition();
            definition.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(definition);
        }
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
            {
                TextBlock text = new TextBlock();
                text.Text = string.Format("column: {0}, row: {1}", j, i);
                text.FontSize = 36;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Margin = new Thickness(10, 10, 10, 10);
                grid.Children.Add(text);
                Grid.SetRow(text, i);
                Grid.SetColumn(text, j);
            }
    }
