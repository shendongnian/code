    public DataTable Macierz;
    public MainWindow()
    {
        InitializeComponent();
        Macierz = new DataTable("Table");
        Macierz.Columns.Add("Col1", typeof(int));
        Macierz.Columns.Add("Col2", typeof(int));
        Macierz.Columns.Add("Col3", typeof(int));
        DataRow row1 = Macierz.NewRow();
        row1["Col1"] = 1;
        row1["Col2"] = 2;
        row1["Col3"] = 3;
        Macierz.Rows.Add(row1);
        DataRow row2 = Macierz.NewRow();
        row2["Col1"] = 4;
        row2["Col2"] = 5;
        row2["Col3"] = 6;
        Macierz.Rows.Add(row2);
        myGrid.DataContext = this;
        myGrid.ItemsSource = Macierz.DefaultView;
    }
