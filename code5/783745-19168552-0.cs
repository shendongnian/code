    // generate rows and columns
    for (int i = 0; i < gridSize; i++)
    {
        gridPanel.RowDefinitions.Add(new RowDefinition());
        gridPanel.ColumnDefinitions.Add(new ColumnDefinition());
    }
    for (int i = 0; i < gridSize; i++)
    {
        gridPanel.RowDefinitions.Add(new RowDefinition());
        for (int j = 0; j < gridSize; j++)
        {
            buttons[i, j] = new Button
                {
                    Content = "0",
                    FontSize = 16,
                    Foreground = new SolidColorBrush(Colors.Transparent),
                    // all buttons have the same margin, no calculation needed
                    Margin = new Thickness(-12) 
                };
            // placing in a row and column via attached properties
            buttons[i, j].SetValue(Grid.RowProperty, i);
            buttons[i, j].SetValue(Grid.ColumnProperty, j);
            buttons[i, j].Click += new RoutedEventHandler(cell_Click);
            opened[i, j] = false;
            this.gridPanel.Children.Add(buttons[i, j]);
        }
    }
