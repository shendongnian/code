    DataTable dt = new DataTable();
    dt.Columns.Add("ID");
    dt.Columns.Add("NAME");
    
    dt.Rows.Add(1, "One");
    dt.Rows.Add(2, "Two");
    dt.Rows.Add(3, "Three");
    dt.PrimaryKey = new DataColumn[] { dt1.Columns["ID"] };
    
    Parallel.ForEach(dt.AsEnumerable(), row =>
    {
        int rowId = int.Parse(row["ID"]);
        string rowName = row["NAME"].ToString();
        //TO DO the routine that useful for each DataRow object...
    });
