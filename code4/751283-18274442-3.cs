    var source = new DataTable();
    source.Columns.Add(new DataColumn("TableName", typeof(string)));
    source.Columns.Add(new DataColumn("RowId", typeof(int)));
    source.Columns.Add(new DataColumn("ColumnName", typeof(string)));
    source.Columns.Add(new DataColumn("ColumnValue", typeof(string)));
    source.Rows.Add("A", 1, "C1", "V1");
    source.Rows.Add("A", 1, "C2", "V2");
    source.Rows.Add("A", 2, "C1", "V3");
    source.Rows.Add("A", 2, "C2", "V4");
