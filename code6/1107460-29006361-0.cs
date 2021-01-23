    int normalRowHeight = -1;
    UcRowDisplay display = new UcRowDisplay();
    DataGridViewRow selectedRow = null;
    public Form1()
    {
        InitializeComponent();
        // create one display object
        display = new UcRowDisplay();
        display.Visible = false;
        display.Parent = DGV;
    }
