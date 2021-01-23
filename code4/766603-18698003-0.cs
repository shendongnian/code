     List<Item> songList = new List<Item>();
               
     var w = new SharpGIS.GZipWebClient();
     Observable.FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted")
        .Subscribe(r =>
        {
            var deserialized = JsonConvert.DeserializeObject<Phone>(r.EventArgs.Result);
                      songList = deserialized.songs.items;
            List<ExtendedItem> extendedItemList = organizeBundleAndUri(songList);
            // DoSomethingElse(extendedItemList);
        });
     w.DownloadStringAsync(new Uri("http://myURL.com/"));
