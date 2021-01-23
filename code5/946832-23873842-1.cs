    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadTableData();
        }
    }
    protected void LoadTableData()
    {
        Table1.Rows.Clear(); //I added this
        TableRow[] tRows = new TableRow[5];
        TableCell[] tCells = new TableCell[5];
        for (int i = 0; i < 5; i++)
        {
            tRows[i] = new TableRow();
            Table1.Rows.Add(tRows[i]);
            tCells[i] = new TableCell();
            tRows[i].Cells.Add(tCells[i]);
            tCells[i].Text = "Cell Number: " + i.ToString();
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        LoadTableData();
    }
