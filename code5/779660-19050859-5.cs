    var table1 = new DataTable();
    table1.Columns.Add("ID", typeof(int));
    table1.Columns.Add("Name");
    var table2 = table1.Clone();
    table1.Rows.Add(1, "inam");
    table1.Rows.Add(2, "Sohan");
    table2.Rows.Add(3, "ranjan");
    table2.Rows.Add(1, "inam");
    table2.Rows.Add(2, "Sohan");
