    string text;
    using (WebClient client = new WebClient())
    {
        text = client.DownloadString(url);
    }
    // Now use text
