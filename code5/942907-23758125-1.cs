    public void Populate()
    {
        IList<Product> products = LoadFromDatabase(); // Function to load database records as Product class instances.
        myListBox.ItemsSource = products;
    }
