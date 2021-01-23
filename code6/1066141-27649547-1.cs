    public async void load(object sender, RoutedEventArgs e)
        {
           StorageFile file = await openFile();        
           List<Pays> listCountries = await splitFile(file);
    }
