    public MainWindow()
    {
            InitializeComponent();
            DataGrid innergrid = new DataGrid();
            InnerClass ic = new InnerClass();
            ic.InnerData = "InnerXYZ";
            innergrid.Items.Add(ic);
            Address ac = new Address() { Id = "100",Name ="Vimal" };
            Address ac1 = new Address(){Id ="101", Name= "Vimal 1"};
            AddressClass add = new AddressClass();
            add.AddItems(ac);
            add.AddItems(ac1);
            myDataGrid.Items.Add(add);
            myDataGrid.MinRowHeight = 100;
            myDataGrid.MinColumnWidth = 250;
        }
