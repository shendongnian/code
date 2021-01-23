    var item = new { Id = 1, Name = "Bob", Age = 30 };
    var item2 = new { Id = 2, Name = "Jane", Age = 26 };
    var item3 = new { Id = 3, Name = "Dave", Age = 42 };
    var items = new[] { item, item2, item3 }.ToList();
    DataGrid.ItemsSource = items;
