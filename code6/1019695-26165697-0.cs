    private void DownloadFile(string url, string path)
    {
        using (var client = new System.Net.WebClient())
        {
            client.DownloadFileAsync(new Uri(url), path);
        }
    }
