    var webClient = new WebClient();
    var result = webClient.DownloadData(url);
    var contentType = webClient.ResponseHeaders["Content-Type"];
        
    if (contentType != null && 
        contentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
    {
        // it's probably an image
    }
