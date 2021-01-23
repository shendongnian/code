    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        ListBoxControl.ItemsSource = await Task.Run(
            () =>
            {
                var list = new List<Person>();
                list.AddRange(Enumerable.Range(1, 1000000).Select(x => new Person(x)));
                return list;
            }
        );
    }
