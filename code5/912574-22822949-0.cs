    var one = BuildDataTable();
    one.PrimaryKey = new DataColumn[] { one.Columns["code"]}; 
    
    var row = one.NewRow();
    row["id"] = "1";
    row["code"] = 1;
    row["val"] = 5.6;
    row["date_time"] = DateTime.Now;
    one.Rows.Add(row);
    
    
    var two = BuildDataTable();
    two.PrimaryKey = new DataColumn[] { two.Columns["date_time"] , two.Columns["code"]};
    
    row = two.NewRow();
    row["id"] = "1";
    row["code"] = 2;
    row["val"] = 3.0;
    row["date_time"] = DateTime.Now.AddDays(1);
    two.Rows.Add(row);
    
    // merge table result
    var merged = BuildDataTable();
    merged.PrimaryKey = new DataColumn[] { 
                            merged.Columns["date_time"] , 
                            merged.Columns["code"]};
    
    // for each table call merge on our merged table
    merged.Merge(one, true, MissingSchemaAction.Ignore); 
    merged.Merge(two, true, MissingSchemaAction.Ignore);
    // continue calling Merge until all tables are done
   
