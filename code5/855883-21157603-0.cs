    isBusy = true;
    isBusyMessage = "Loading...";
        WebClient client = new WebClient();
        Uri uri = new Uri(transportURL1 + latitude + "%2C" + longitude + transportURL2, UriKind.Absolute);
        client.DownloadStringCompleted += (s, e) =>
        {
            if (e.Error == null)
            {
                RootObject result = JsonConvert.DeserializeObject<RootObject>(e.Result);
                hereRestProperty = new ObservableCollection<Item>(result.results.items);
            }
            else
            {
                MessageBox.Show(e.Error.ToString());
            }
            // Dispatcher.Invoke for lines below, if needed
            // Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => {
            isBusy = false;
            isBusyMessage = "Finished";
            // }));
        };
        client.DownloadStringAsync(uri);
