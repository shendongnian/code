     DataTable table = new DataTable();
     table.Columns.Add("Column 1");
     table.Columns.Add("Column 2");
     table.Columns.Add("Column 3");
     table.Columns.AddColumnAfter("Column 1", new DataColumn("Column 4"));
