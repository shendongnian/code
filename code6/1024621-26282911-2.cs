    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var invoices = await Task.Run(() => db.Invoices.AsNoTracking().ToList());
        listbox1.ItemsSource = invoices;
    }
