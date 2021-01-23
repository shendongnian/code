    List<string[]> list = new List<string[]>();
    	    list.Add(new string[] { "Column 1", "Column 2", "Column 3" });
    	    list.Add(new string[] { "Row 2", "Row 2" });
    	    list.Add(new string[] { "Row 3" });
    
    	    // Convert to DataTable.
    	    DataTable table = ConvertListToDataTable(list);
    	    dataGridView1.DataSource = table;
