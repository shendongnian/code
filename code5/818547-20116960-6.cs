    var item = new { Id = 1, Name = "Bob", Age = 30, Date = DateTime.Now };
    var item2 = new { Id = 2, Name = "Jane", Age = 26, Date = DateTime.Now };
    var item3 = new { Id = 3, Name = "Dave", Age = 42, Date = DateTime.Now };
    var items = new[] { item, item2, item3 }.ToList();
    DataGrid.ItemsSource = items;
