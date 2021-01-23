    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("A", typeof(string)));
    dt.Columns.Add(new DataColumn("B", typeof(string)));
    dt.Columns.Add(new DataColumn("C", typeof(int)));
    
    dt.Rows.Add(new object[] { "1001", "Null", 10 });
    dt.Rows.Add(new object[] { "1001", "W101", 5 });
    dt.Rows.Add(new object[] { "1001", "W102", 4 });
    dt.Rows.Add(new object[] { "1001", "W103", 1 });
    
    dt.Rows.Add(new object[] { "1002", "Null", 12 });
    dt.Rows.Add(new object[] { "1002", "W104", 5 });
    dt.Rows.Add(new object[] { "1002", "W105", 3 });
    
    dt.Rows.Add(new object[] { "1003", "W106", 5 });
    dt.Rows.Add(new object[] { "1003", "W107", 2 });
