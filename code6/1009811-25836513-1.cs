    internal async Task Upload(Windows.Storage.StorageFile file)
    {
        var fileStream = await file.OpenAsync(FileAccessMode.Read);
        fileStream.Seek(0);
        var reader = new Windows.Storage.Streams.DataReader(fileStream.GetInputStreamAt(0));
        await reader.LoadAsync((uint)fileStream.Size);
        Globals.MemberId = ApplicationData.Current.LocalSettings.Values[Globals.PROFILE_KEY];
        var userName = "Rico";
        var sex = 1;
        var url = string.Format("{0}{1}?memberid={2}&name={3}&sex={4}", Globals.URL_PREFIX, "api/Images", Globals.MemberId, userName,sex);
        byte[] image = new byte[fileStream.Size];
        await UploadImage(image, url);
    }
