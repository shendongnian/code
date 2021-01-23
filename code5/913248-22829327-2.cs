    private static String[,] Rss_read(string connection)
    {
        string[,] feedData = new string[40, 3];
        WebClient client = new WebClient();
        XmlDocument rssxmlDoc = new XmlDocument();
        string downloadString = client.DownloadString(connection);
        rssxmlDoc.LoadXml(downloadString);   ///statement which return exception;    
        XmlNodeList rssItme = rssxmlDoc.SelectNodes("rss/ chanel/item");
        for (int i = 0; i < rssItme.Count; i++)
        {
            // Your logic here
        }
        return feedData;
    }
