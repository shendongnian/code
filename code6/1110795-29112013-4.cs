    protected ScreenViewModel ScreenViewModel
    {
        get
        {
            return this.Resources["GridViewModel"] as ScreenViewModel;
        }
    }
    protected CellGridController Controller
    {
        get
        {
            return this.Resources["CellController"] as CellGridController;
        }
    }
    protected void Load()
    {
        var controller = Controller;
        controller.Collection.Clear();
        string[] rows = colorToCellSource.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        string row;
        for (int x = 0; x < rows.Length; x++)
        {
            int length = rows[x].Length;
            ScreenViewModel.Rows = rows.Length;
            ScreenViewModel.Columns = length;
            row = rows[x];
            for (int y = 0; y < length; y++)
            {
                Cell cell = new Cell(x, y);
                cell.CellColor = row[y] == '0' ? Brushes.Transparent : Brushes.Blue;
                controller.Collection.Add(cell);
            }
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        if (Controller != null && ScreenViewModel != null)
        {
            ScreenViewModel.Cells = Controller.Collection;
            Load();
        }
    }
