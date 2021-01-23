    public static Task<List<SyndicationItem>> Execute(string link)
    {
        WebClient wc = new WebClient();
        TaskCompletionSource<List<SyndicationItem>> tcs = new TaskCompletionSource<List<SyndicationItem>>();
        wc.DownloadStringCompleted += (s, e) =>
        {
            if (e.Error == null)
            {
                StringReader stringReader = new StringReader(e.Result);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
                tcs.SetResult(new List<SyndicationItem>(feed.Items));
            }
            else
            {
                tcs.SetResult(new List<SyndicationItem>());
            }
        };
        wc.DownloadStringAsync(new Uri(link, UriKind.Absolute));
        return tcs.Task;
    }
