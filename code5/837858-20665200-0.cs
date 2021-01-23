    // Your original code.
    HttpClientHandler aHandler = new HttpClientHandler();
    aHandler.ClientCertificateOptions = ClientCertificateOption.Automatic;
    HttpClient aClient = new HttpClient(aHandler);
    aClient.DefaultRequestHeaders.ExpectContinue = false;
    HttpResponseMessage response = await aClient.GetAsync(
        url,
        HttpCompletionOption.ResponseHeadersRead); // Important! ResponseHeadersRead.
    // To save downloaded image to local storage
    var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(
        filename,
        CreationCollisionOption.ReplaceExisting);
    var fs = await imageFile.OpenAsync(FileAccessMode.ReadWrite);
    // New code.
    Stream stream = await response.Content.ReadAsStreamAsync();
    IInputStream inputStream = stream.AsInputStream();
    ulong totalBytesRead = 0;
    while (true)
    {
        // Read from the web.
        IBuffer buffer = new Windows.Storage.Streams.Buffer(1024);
        buffer = await inputStream.ReadAsync(
            buffer,
            buffer.Capacity,
            InputStreamOptions.None);
        if (buffer.Length == 0)
        {
            // There is nothing else to read.
            break;
        }
        // Report progress.
        totalBytesRead += buffer.Length;
        System.Diagnostics.Debug.WriteLine("Bytes read: {0}", totalBytesRead);
        // Write to file.
        await fs.WriteAsync(buffer);
    }
    inputStream.Dispose();
    fs.Dispose();
