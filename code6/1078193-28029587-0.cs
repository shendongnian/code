    using (var webClient = new System.Net.WebClient())
    {
        webClient.Headers.Add("Authentication-Token", apiKey);
        var myTable = webClient.DownloadString(url);
        ...
    }
