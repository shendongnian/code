    private async void StartButton_Click(object sender, EventArgs e)
    {
        List<string> ImageURI;
        GenerateURIs(out ImageURI); // creates list of 1000 uris
        
        var requests = ImageURI
            .Select(uri => (new WebClient()).DownloadDataTaskAsync(uri))
            .Select(SaveImageFile);
        await Task.WhenAll(requests);
    }
    private Task SaveImageFile(Task<byte[]> data)
    {
        try
        {
            byte[] ImageBytes = await data;
            DownloadedImages++;
            if (ImageBytes.Length == 503)
            {
                InvalidImages++;
                return;
            }
            ValidImages++;
            using (var file = new FileStream("images/" + (++FilesIndex).ToString() + ".png", FileMode.Append, FileAccess.Write))
            {
                await Writer.WriteAsync(ImageBytes, 0, ImageBytes.Length);
            }
        }
        catch (Exception e)
        {
        }            
        return;
    }
