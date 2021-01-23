    public async void LoadData()
        {
           LiveConnectClient client = new LiveConnectClient(App.Session);
            LiveOperationResult albumOperationResult = await client.GetAsync("me/albums");
            dynamic albumResult = albumOperationResult.Result;
            foreach (dynamic album in albumResult.data)
            {
                var group = new SkyDriveAlbum(album.id, album.name, album.name, @"ms-appx:///Assets/DarkGray.png", album.description);
                LiveOperationResult pictureOperationResult = await client.GetAsync(album.id + "/files");
                dynamic pictureResult = pictureOperationResult.Result;
                foreach (dynamic picture in pictureResult.data)
                {
                    var pictureItem = new SkyDriveItem(picture.id, picture.name, picture.name, picture.source, picture.description, picture.description, group);
                    group.Items.Add(pictureItem);
                }
                this.AllGroups.Add(group);
            }
        }
