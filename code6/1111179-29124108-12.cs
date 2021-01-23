    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!Page.IsPostBack)
    		InitialDataLoad();
    }
    
    private void InitialDataLoad()
    {
    	var dt = new DataTable();
    	dt.Columns.Add("Tasks");
    	dt.Columns.Add("AnotherColumn");
    
    	var dr = dt.NewRow();
    	dr[0] = "task1";
    	dr[1] = "c1";
    	dt.Rows.Add(dr);
    
    	GridView1.DataSource = dt;
    	GridView1.DataBind();
    
    	Session["dt"] = dt;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
    	// adds a row
    
    	var dt = Session["dt"] as DataTable;
    
    	if (dt != null)
    	{
    		var dr = dt.NewRow();
    		dr[0] = "anothertask";
    		dr[1] = "c2";
    		dt.Rows.Add(dr);
    
    		GridView1.DataSource = dt;
    		GridView1.DataBind();
    
    		Session["dt"] = dt;
    	}
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
    	// create csv
    
    	var dt = Session["dt"] as DataTable;
    
    	var sb = new StringBuilder();
    
    	IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
    									  Select(column => column.ColumnName);
    
    	sb.AppendLine(string.Join(",", columnNames));
    
    	foreach (DataRow row in dt.Rows)
    	{
    		IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
    		sb.AppendLine(string.Join(",", fields));
    	}
    
    	File.WriteAllText(@"c:\Tasks.csv", sb.ToString());
    }
