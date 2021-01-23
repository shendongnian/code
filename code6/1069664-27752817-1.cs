    // Create some test data.
    DataTable dt = new DataTable();
    dt.Columns.Add("Test", typeof(bool));
    DataRow dr1 = dt.NewRow();
    DataRow dr2 = dt.NewRow();
    DataRow dr3 = dt.NewRow();
                
    dr1["Test"] = true;
    dr2["Test"] = false;
    dr3["Test"] = false;
    
    dt.Rows.Add(dr1);
    dt.Rows.Add(dr2);
    dt.Rows.Add(dr3);
    
    // Get only rows where "Test" column is false.
    var removeRows = dt.AsEnumerable().Where(r => (bool)r["Test"] == false).ToList();
    
    // Remove selected rows.
    foreach (var row in removeRows)
    {
        dt.Rows.Remove(row);
    }
