    Grid grid = new Grid();
    grid.ColumnDefinitions.Add(new ColumnDefinition
        {
            SharedSizeGroup = "MySharedSizedGroupName",
            Width = new GridLength(1.0, GridUnitType.Auto)
        });
    grid.Children.Add(new TextBlock{Text="Tab 5"});
    tabitem2.Header = grid;
