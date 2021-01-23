    int age = 32;
    string column = "Age";
    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Name", typeof(string)));
    dt.Columns.Add(new DataColumn("Age", typeof(int)));
    dt.Rows.Add(new object[] { "John", 32 });
    var result = dt.AsEnumerable().Where(r => Convert.ToInt32(r[column]) == age);
