    private async Task AddItems()
    {
        foreach (var item in Database.SomeTable())
        {
            ItemsSource.Add(item);
            await Task.Delay(1);
        }
    }
