    protected void Page_Load(object sender, EventArgs e)
    {
        RadGrid1.DataSource = BinddataGrid();
    }
    private object[] BinddataGrid()
    {
        return new object[] { 
            new  {ContactTitle = "TEST1"},
            new   {ContactTitle ="TEST2"},
            new   {ContactTitle ="TEST3"},
            new   {ContactTitle ="TEST4"}
            };
    }
