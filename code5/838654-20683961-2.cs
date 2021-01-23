    public MainWindow()
    {
            InitializeComponent();
            DataGrid innergrid = new DataGrid();
            InnerClass ic = new InnerClass();
            ic.InnerData = "InnerXYZ";
            innergrid.Items.Add(ic);
            AddressClass ac = new AddressClass();
            ac.Name = "Vimal";
            ac.AddItems(new AddressClass() { Id = "100", Name = "Vimal" });
            myDataGrid.Items.Add(ac);
            myDataGrid.MinRowHeight = 100;
            myDataGrid.MinColumnWidth = 250;
        }
