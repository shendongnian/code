    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var table = CreateDataTable();
            table.Rows.Add("", "", "");
            BindGridView(table);
        }
    }
    //Sets the first empty row to the grid view
    private DataTable CreateDataTable()
    {
        var dt = new DataTable
        {
            Columns = { "Column1", "Column2", "Column3" }
        };
        return dt;
    }
    private void BindGridView(DataTable table)
    {
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
    private DataTable PopulateTableFromGridView()
    {
        var table = CreateDataTable();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //extract the TextBox values
            TextBox box1 = (TextBox)GridView1.Rows[i].FindControl("txt1");
            TextBox box2 = (TextBox)GridView1.Rows[i].FindControl("txt2");
            TextBox box3 = (TextBox)GridView1.Rows[i].FindControl("txt3");
            table.Rows.Add(box1.Text, box2.Text, box3.Text);
        }
        return table;
    }
    //Adds a new empty row to the grid view
    protected void Add(object sender, EventArgs e)
    {
        var newTable = PopulateTableFromGridView();
        newTable.Rows.Add("", "", "");
        BindGridView(newTable);
    }
    //Called on Delete Button click, which is inside a CommanField
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var dt = PopulateTableFromGridView();
        dt.Rows[e.RowIndex].Delete();
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add("", "", "");
        }
        BindGridView(dt);
    }
