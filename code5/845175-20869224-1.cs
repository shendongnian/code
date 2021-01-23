    /// <summary>
    /// Gets the root dirs from SkyDrive
    /// </summary>
    public void ListSkyDriveRootAlbums()
    {
        List<SkydriveAlbum> albums = new List<SkydriveAlbum>();
        LiveConnectClient clientFolder = new LiveConnectClient(App.Session);
        clientFolder.GetCompleted += (sender, e) =>
        {
            if (e.Error == null)
            {
                List<object> data = (List<object>)e.Result["data"];
                foreach (IDictionary<string, object> album in data)
                {
                    SkydriveAlbum albumItem = new SkydriveAlbum();
                    albumItem.Title = (string)album["name"];
                    albumItem.Description = (string)album["description"];
                    albumItem.ID = (string)album["id"];
                    albums.Add(albumItem);
                }
                if (ListAlbumsCompleted != null)
                {
                    ListAlbumsCompleted(albums.ToArray(), e.Error);
                }
            }
            else if (ListAlbumsCompleted != null)
            {
                ListAlbumsCompleted(null, e.Error);
            }
        };
        clientFolder.GetAsync("me/skydrive/files");
    }
