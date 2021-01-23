    var list = new List<MyObject>();
    list.Add(new MyObject { Number = 1, Name = "Char" });
    list.Add(new MyObject { Number = 2, Name = "Amuro" });
    comboBox1.DataSource = list;
    comboBox1.DisplayMember = "Name";
