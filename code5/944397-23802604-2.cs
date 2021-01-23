    foreach (var row in DataTable1.AsEnumerable().Where(r =>
            r.Field<string>("Column1") == DataRowX &&
            r.Field<int>("Column2") == 12 &&
            r.Field<string>("Column3") == "3" &&
            r.Field<string>("Column4") == "0"))
    {
        row.SetField("Column5", intUpdateValueColumnx);
        row.SetField("Column6", intUpdateValueColumny);
    }
    DataTable1.AcceptChanges();
