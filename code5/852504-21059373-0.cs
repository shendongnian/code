    static DataTable GetTable2()
    {
    	DataTable table = new DataTable();
    	var colm= table.Columns.Add("ID", typeof(int));
    	table.PrimaryKey = new DataColumn[] {colm };
    	table.Columns.Add("B", typeof(string));
    	table.Rows.Add( 2, "B2");
    	return table;
    }
    
    
    static DataTable GetTable1()
    {
    	DataTable table = new DataTable();
    	var colm= table.Columns.Add("ID", typeof(int));
    	table.PrimaryKey = new DataColumn[] {colm };
    	table.Columns.Add("A", typeof(string));
    	table.Rows.Add(1, "A1");
    	table.Rows.Add( 2, "A2");
    	return table;
    }
	var tbl = GetTable1();
	tbl.Merge(GetTable2());
