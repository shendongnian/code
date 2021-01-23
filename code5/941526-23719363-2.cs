    using Windows.Web.Http;
    using Windows.Web.Http.Filters;
    private async void Foo(StorageFolder folder, string fileName)
    {
        Uri uri = new Uri("http://localhost");
        var filter = new HttpBaseProtocolFilter();
        filter.ServerCredential =
            new Windows.Security.Credentials.PasswordCredential(uri.ToString(), "foo", "bar");
        var client = new HttpClient(filter);
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
        request.Headers.Add("Range", "bytes=0-");
        // Hook up progress handler.
        Progress<HttpProgress> progressCallback = new Progress<HttpProgress>(OnSendRequestProgress);
        var tokenSource = new CancellationTokenSource();
        HttpResponseMessage response = await client.SendRequestAsync(request).AsTask(tokenSource.Token, progressCallback);
        IInputStream inputStream = await response.Content.ReadAsInputStreamAsync();
        StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.GenerateUniqueName);
        // Copy from stream to stream.
        IOutputStream outputStream = await file.OpenAsync(FileAccessMode.ReadWrite);
        await RandomAccessStream.CopyAndCloseAsync(inputStream, outputStream);
    }
    private void OnSendRequestProgress(HttpProgress obj)
    {
        Debug.WriteLine(obj);
    }
