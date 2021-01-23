    private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs e)
    {
        DataPackage requestData = e.request.Data;
        requestData.Properties.Title = "Target";
        requestData.Properties.Description = webViewModel.Name;
        // Set up the data provider for a long running share operation...
        requestData.SetDataProvider(StandardDataFormats.Bitmap, OnDeferredRequestedHandler);
    }
    private async void OnDeferredRequestedHandler(DataProviderRequest providerRequest)
    {
        // Again, get a deferral as an asynchronous method is called
        DataProviderDeferral deferral = providerRequest.GetDeferral();
        
        // Code to do screen capture...
        deferral.Complete();
    }
