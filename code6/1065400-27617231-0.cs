    using (WebClient webClient = new WebClient())
    {
        webClient.DownloadFile(
            url,
            path);
    }
    
