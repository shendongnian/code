    Encoding encoding = null;
    using (WebClient client = new WebClient())
    {
        string html = client.DownloadString(websiteUrl);
        encoding = doc.DetectEncodingHtml(html);
    }
