    public async void DownloadTrack(Uri SongUri)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            var data = await httpClient.GetByteArrayAsync(SongUri);
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Test.mp3", CreationCollisionOption.ReplaceExisting);
            using (var targetStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await targetStream.AsStreamForWrite().WriteAsync(data, 0, data.Length);
                await targetStream.FlushAsync();
            }
        }
    }
