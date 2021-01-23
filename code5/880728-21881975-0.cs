    public MainWindow()
    {
        var rows = new List<RowObj>();
        for (int i = 0; i < 5000; i++)
        {
            rows.Add(new RowObj
            {
                Col0 = "col0," + i,
                Col1 = "col1," + i,
                Col2 = "col2," + i,
                Col3 = "col3," + i,
                Col4 = "col4," + i,
            });
        }
        InitializeComponent();
    
        mainTable.ItemsSource = rows;
    }
