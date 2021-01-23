    private void AddNewProduct(object sender, RoutedEventArgs e)
    {
        NewProductInput productInputWindow = new NewProductInput();
        productInputWindow.Show();
        productInputWindow.Closed += OnProductInputWindowClosed;
    }
    private void OnProductInputWindowClosed(object sender, RoutedEventArgs e)
    {
        (sender as Window).Closed -= OnProductInputWindowClosed;
        Products = new ObservableCollection<Product>(DbContext.Products);
    }
