    private Task<bool> myTask()            
    {
        isBusy = true;
        isBusyMessage = "Loading...";
        WebClient client = new WebClient();
        Uri uri = new Uri(transportURL1 + latitude + "%2C" + longitude + transportURL2, UriKind.Absolute);
        await client.DownloadStringAsync(uri);
        try
        {
           RootObject result = JsonConvert.DeserializeObject<RootObject>(e.Result);
           hereRestProperty = new ObservableCollection<Item>(result.results.items);
        }
        catch (Exception err)                 
        {
           MessageBox.Show(err.Message);
           isBusy = false;
           isBusyMessage = "Finished";
           return false;
        }
        isBusy = false;
        isBusyMessage = "Finished";
        return true;
    }
