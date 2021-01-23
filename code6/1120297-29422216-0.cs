    DataTable dt1 = new DataTable();
    DataColumn dc = new DataColumn("col1", Type.GetType("System.String"));
    dt1.Columns.Add(dc);
    dt1.Rows.Add(new Object[]{"a"});    
    dt1.Rows.Add(new Object[]{"c"});
    
    DataTable dt2 = new DataTable();
    dc = new DataColumn("col2", Type.GetType("System.String"));
    dt2.Columns.Add(dc);
    dt2.Rows.Add(new Object[]{"p"});    
    dt2.Rows.Add(new Object[]{"q"});
    
    DataTable dtResult = new DataTable();
    dc = new DataColumn("index", Type.GetType("System.Int32"));
    dtResult.Columns.Add(dc);
    dc = new DataColumn("col1", Type.GetType("System.String"));
    dtResult.Columns.Add(dc);
    dc = new DataColumn("col2", Type.GetType("System.String"));
    dtResult.Columns.Add(dc);
    
    var dtRows = from r1 in dt1.AsEnumerable().Select((x,y)=>new{col1 = x.Field<string>("col1"), index = y})
    		join r2 in dt2.AsEnumerable().Select((x,y)=>new{col2 = x.Field<string>("col2"), index = y}) on r1.index equals r2.index
    		select dtResult.LoadDataRow(new Object[]{r1.index, r1.col1, r2.col2}, true);
    dtRows.CopyToDataTable();
    dtResult.Dump();
