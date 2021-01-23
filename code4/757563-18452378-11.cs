    var names = new string[] { "Name1", "Name2" };
    foreach (string name in names)
    {
        grid.Columns.Add(new DataGridTextColumn { Binding = new Binding("Custom[" + name + "]"), Header = name });
    }
