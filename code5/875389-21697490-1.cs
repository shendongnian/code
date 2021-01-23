    private void dataGridInit()
    {
        SortedList<int, Person> list = new SortedList<int, Person>();
        list.Add(2, new Person() {Name = "James", Age = 30, Address = "some place" });
        list.Add(1, new Person() { Name = "Kitty", Age = 28, Address = "some place" });
        list.Add(3, new Person() { Name = "Deko", Age = 28, Address = "some place" });
        dataGrid.DataContext = list;
        dataGrid.ItemsSource = list;
    }
