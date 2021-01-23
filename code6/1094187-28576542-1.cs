    private void DownloadFile(string url)
    {
        var filePath = SelectDestinationFile();
        if(string.IsNullOrWhiteSpace(filePath))
           throw new InvalidOperationException("invalid file path");
        using (var client = new WebClient())
           client.DownloadFile(url, filePath);
    }
