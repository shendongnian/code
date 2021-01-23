    private async void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs e)
    {
        e.Request.Data.Properties.Title = "THIS IS A TITLE";
        e.Request.Data.Properties.Description = "THIS IS A DESCRIPTION";
        e.Request.Data.Properties.FileTypes.Add(".txt");
        var file = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("SCLogFile.txt");
        e.Request.Data.SetStorageItems(file);
    }
