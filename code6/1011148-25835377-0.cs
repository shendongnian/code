    public async void GetRSS()
    {
        HttpClient httpClient = new HttpClient();
        var rssContent = await httpClient.GetStringAsync("http://teknoseyir.com/feed");
        var RssData = from rss in XElement.Parse(rssContent).Descendants("item")
                      .....
                      .....
        RssList.ItemsSource = RssData;
    }
