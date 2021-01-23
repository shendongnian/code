    public void buildUIGrid(Grid g) {
    
    
            g.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200, GridUnitType.Pixel) });
            g.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(200, GridUnitType.Pixel) });
    
            int i, j; i = 0; j = 0;
            TextBlock tb = new TextBlock();
            tb.Text = "test at col "+i+", row "+j;
            Grid.SetColumn(tb, i);
            Grid.SetRow(tb, j);
            g.Children.Add(tb);
                
        }
