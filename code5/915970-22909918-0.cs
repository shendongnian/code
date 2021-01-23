    DataTable dtN = new DataTable();
    
    dtN.Columns.Add("Id");
    dtN.Columns.Add("Name");
    dtN.AcceptChanges();
    
    for (int i = 1; i <= 10; i++)
    {
        DataRow dr = dtN.NewRow();
        dr["Id"] = i;
        dr["Name"] = "A" + i.ToString();
        dtN.Rows.Add(dr);
        dtN.AcceptChanges();
    }
    
    var data = from r in dtN.AsEnumerable()
                select new { Name = r["Name"].ToString() };
    
    DataTable dt = new DataTable();
    dt.Columns.Add("Name");
    foreach(var s in data)
    {
        DataRow dr = dt.NewRow();
        dr["Name"] = s.Name;
        dt.Rows.Add(dr);
        dt.AcceptChanges();
    }
    //DataTable dt = data.CopyToDataTable();
