    public static async Task<string> DownloadFileOfCustomerAssetRow(int? id, int? version, string filename, IProgress<int> progress)
    {
        HttpClientHandler aHandler = new HttpClientHandler();
        aHandler.ClientCertificateOptions = ClientCertificateOption.Automatic;
        HttpClient aClient = new HttpClient(aHandler);
        customerAssetRow.CurrentFileDownload = aClient;
        aClient.DefaultRequestHeaders.ExpectContinue = false;
        HttpResponseMessage response = await aClient.GetAsync(WebServices.BackendStartUrl + "getFileData?id=" + id + "&version=" + version, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.GenerateUniqueName).ConfigureAwait(false);
        fileRow.FileName = file.Name;
        using (var fs = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite).ConfigureAwait(false))
        {
            Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            IInputStream inputStream = stream.AsInputStream();
            ulong totalBytesRead = 0;
            while (true)
            {
                IBuffer buffer = new Windows.Storage.Streams.Buffer(1024);
                buffer = await inputStream.ReadAsync(
                    buffer,
                    buffer.Capacity,
                    InputStreamOptions.None).ConfigureAwait(false);
                if (buffer.Length == 0)
                {
                    break;
                }
                totalBytesRead += buffer.Length;
                if (progress != null)
                    progress.Report(totalBytesRead);
                await fs.WriteAsync(buffer).ConfigureAwait(false);
            }
            inputStream.Dispose();
        }
        return file.Name;
    }
