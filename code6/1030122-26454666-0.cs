    DataTable table = new DataTable();
    table.Columns.Add(new DataColumn("A", typeof (DateTime)));
    DateTime dt = new DateTime(2000, 1, 1, 1, 1, 1, 10);
    table.Rows.Add(dt);
    table.Rows.Add(DateTime.Now);
    DataRow[] rows = table.Select("A = #" + dt.ToString("yyyy-MM-dd HH:mm:ss.fff") + "#");
