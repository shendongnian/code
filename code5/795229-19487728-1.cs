    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grd.DataSource = GetTableWithInitialData(); // get first initial data
            grd.DataBind();
        }
    }
    
    public DataTable GetTableWithInitialData() // this might be your sp for select
    {
        DataTable table = new DataTable();
        table.Columns.Add("PayScale", typeof(string));
        table.Columns.Add("IncrementAmount", typeof(string));
        table.Columns.Add("Period", typeof(string));
    
        table.Rows.Add(1, "David", "1");
        table.Rows.Add(2, "Sam", "2");
        table.Rows.Add(3, "Christoff", "1.5");
        return table;
    }
    
    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        DataTable dt = GetTableWithNoData(); // get select column header only records not required
        DataRow dr;
    
        foreach (GridViewRow gvr in grd.Rows)
        {
            dr = dt.NewRow();
    
            TextBox txtPayScale = gvr.FindControl("txtPayScale") as TextBox;
            TextBox txtIncrementAmount = gvr.FindControl("txtIncrementAmount") as TextBox;
            TextBox txtPeriod = gvr.FindControl("txtPeriod") as TextBox;
    
            dr[0] = txtPayScale.Text;
            dr[1] = txtIncrementAmount.Text;
            dr[2] = txtPeriod.Text;
    
            dt.Rows.Add(dr); // add grid values in to row and add row to the blank table
        }
    
        dr = dt.NewRow(); // add last empty row
        dt.Rows.Add(dr);
    
        grd.DataSource = dt; // bind new datatable to grid
        grd.DataBind();
    }
    
    public DataTable GetTableWithNoData() // returns only structure if the select columns
    {
        DataTable table = new DataTable();
        table.Columns.Add("PayScale", typeof(string));
        table.Columns.Add("IncrementAmount", typeof(string));
        table.Columns.Add("Period", typeof(string));
        return table;
    }
