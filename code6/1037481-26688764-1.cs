    protected void Page_Load(object sender, EventArgs e)
    {
        BuildControls();
    }
    public void BuildControls()
    {
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        tc.Text = "hello world";
        tc.ID = "h1";
        tr.Cells.Add(tc);
    
        tc = new TableCell();
        tc.Text = "hello world1";
        tc.ID = "h2";
        tr.Cells.Add(tc);
    
        tbl.Rows.Add(tr);
    }
    
    protected void btn_Click(object sender, EventArgs e)
    {
        TableCell c1 = (TableCell)tbl.FindControl("h1");
        string val1 = c1.Text;
        TableCell c2 = (TableCell)tbl.FindControl("h2");
        string val2 = c2.Text;
    }
