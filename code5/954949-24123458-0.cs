    private async void ShareStorageItemsHandler(DataTransferManager sender, 
        DataRequestedEventArgs e)
    {
        DataRequest request = e.Request;
        request.Data.Properties.Title = "Share StorageItems Example";
        request.Data.Properties.Description = "Demonstrates how to share files.";
    
        // Because we are making async calls in the DataRequested event handler,
        // we need to get the deferral first.
        DataRequestDeferral deferral = request.GetDeferral();  
        // Make sure we always call Complete on the deferral.
        try
        {
            StorageFile logoFile = 
                await Package.Current.InstalledLocation.GetFileAsync("Assets\\Logo.png");
            List<IStorageItem> storageItems = new List<IStorageItem>();
            storageItems.Add(logoFile);
            request.Data.SetStorageItems(storageItems);       
        }
        finally
        {
            deferral.Complete();
        }
    }
