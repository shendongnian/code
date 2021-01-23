    DataTable dt = new DataTable();
    DataColumn c = new DataColumn();
    c.DataType = typeof(string);
    c.Name = "Product Name";
    dt.Columns.Add(c);
    c = new DataColumn();
    c.DataType = typeof(decimal);
    c.Name = "Cost";
    dt.Columns.Add(c);
    
    while (dr4.Read())
    {
        DataRow r = dt.NewRow();
        r["Product Name"] = dr4["ProductName"].ToString();
        r["Cost"] = dr4["Cost"].ToString();
        dt.Rows.Add(r);
    }
