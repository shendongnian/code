    var t1Rows = Table1.AsEnumerable();
    foreach (DataRow row in Table2.Rows)
    {
        DataRow row1 = t1Rows.FirstOrDefault(r => 
            row.Field<int>("ColA1") == r.Field<int>("ColA1"));
        if (row1 != null)
            row.SetField("ColA2", row1.Field<string>("ColA2"));
    }
