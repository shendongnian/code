    // create a dataset
    DataSet ds = new DataSet();
    
    // create a datatable
    DataTable dt = new DataTable();
    
    // add the columns into this table
    dt.Columns.Add("col1");
    dt.Columns.Add("col2");
    dt.Columns.Add("col3");
    dt.Columns.Add("col4");
    
    // add this table to dataset
    ds.Tables.Add(dt);
