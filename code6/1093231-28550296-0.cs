    public MainWindow()
    {
        InitializeComponent();
    
        var numRows = grid.RowDefinitions.Count;
        var numCols = grid.ColumnDefinitions.Count;
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                var item = new DynamicGridItem(j, i);
                item.Merge += HandleMerge;
                item.Split += HandleSplit;
                grid.Children.Add(item);
                Grid.SetRow(item, i);
                Grid.SetColumn(item, j);
            }
        }
    }
