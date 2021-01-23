    public Form1()
    {
    	InitializeComponent();
    
    	LoadData();
    }
    
    private void LoadData()
    {
    	var dt = new DataTable();
    	dt.Columns.Add("Tasks");
    	dt.Columns.Add("AnotherColumn");
    
    	DataRow dr = dt.NewRow();
    	dr[0] = "task1";
    	dr[1] = "c1";
    	dt.Rows.Add(dr);
    
    	DataRow dr2 = dt.NewRow();
    	dr2[0] = "test2";
    	dr2[1] = "c2";
    	dt.Rows.Add(dr2);
    
    	dataGridView1.DataSource = dt;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	var editedDataTable = (DataTable)(dataGridView1.DataSource);
    
    	WriteCsvFile(editedDataTable);
    }
    
    private static void WriteCsvFile(DataTable editedDataTable)
    {
    	var sb = new StringBuilder();
    
    	IEnumerable<string> columnNames = editedDataTable.Columns.Cast<DataColumn>().
    									  Select(column => column.ColumnName);
    
    	sb.AppendLine(string.Join(",", columnNames));
    
    	foreach (DataRow row in editedDataTable.Rows)
    	{
    		IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
    		sb.AppendLine(string.Join(",", fields));
    	}
    
    	File.WriteAllText(@"c:\Tasks.csv", sb.ToString());
    }
