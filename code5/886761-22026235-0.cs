    //This Section should be outside your loop 
    DataTable dt = new DataTable();
    DataColumn dc = new DataColumn("col1", typeof(String));
    dt.Columns.Add(dc);
    
    dc = new DataColumn("col2", typeof(String));
    dt.Columns.Add(dc);
    
    dc = new DataColumn("col3", typeof(String));
    dt.Columns.Add(dc);
    
    dc = new DataColumn("col4", typeof(String));
    dt.Columns.Add(dc);
    //End of section
    //Inside your loop 
    DataRow dr = dt.NewRow();
    
    dr[0] = "coldata1";
    dr[1] = "coldata2";
    dr[2] = "coldata3";
    dr[3] = "coldata4";
    
    dt.Rows.Add(dr);
