    var list = new List<MyData>();
    list.Add(new MyData() { ID = 5, Text = "5", new DateTime(2012, 5, 1) });
    list.Add(new MyData() { ID = 7, Text = "7", new DateTime(2012, 7, 1) });
    list.Add(new MyData() { ID = 9, Text = "9", new DateTime(2012, 9, 1) });
    table.DataSource = list;
