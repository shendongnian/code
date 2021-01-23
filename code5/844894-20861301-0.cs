    public DataTable ConvertToDataTable (string filePath, int numberOfColumns)
    {
        DataTable tbl = new DataTable();
    
        for(int col =0; col < numberOfColumns; col++)
            tbl.Columns.Add(new DataColumn("Column" + (col+1).ToString()));
    	
    	
        string[] lines = System.IO.File.ReadAllLines(filePath);
    	
        foreach(string line in lines)
        {
    	    var cols = line.Split(':');
    	    DataRow dr = tbl.NewRow();
    	    for(int cIndex=0; cIndex < 3; cIndex++)
    	    {
    	       dr[cIndex] = cols[cIndex];
    	    }
    	    tbl.Rows.Add(dr);
        }
    
        return tbl;
    }
