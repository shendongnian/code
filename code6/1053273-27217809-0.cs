    var items = new List<User>();
    items.Add(new User() { Name = "John Doe", Age = 42 });
    items.Add(new User() { Name = "Jane Doe", Age = 39 });
    items.Add(new User() { Name = "Sammy Doe", Age = 13 });
    myListView.ItemsSource = items;
