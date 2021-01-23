    var items = grid.ItemsSource as IEnumerable<MyModel>;
    foreach (var item in items)
    {
        var container = grid.ContainerFromItem(item);
        var button = Children(container)
            .Where(x => x is Button)
            .Select(x => x as Button)
            .Where(x => x.Name.Equals("MyButton"))
            .FirstOrDefault();
        if (button == null)
            continue;
        if (item.ShouldBeVisible)
            button.Visibility = Visibility.Visible;
        else
            button.Visibility = Visibility.Collapsed;
    }
