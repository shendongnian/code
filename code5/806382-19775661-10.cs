	var feedUrl = @"http://jobs.huskyenergy.com/RSS";
	try
	{
		var webClient = new WebClient();
		// hide ;-)
		webClient.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
		// fetch feed as string
		var content = webClient.OpenRead(feedUrl);
		var contentReader = new StreamReader(content);
		var rssFeedAsString = contentReader.ReadToEnd();
		// convert feed to XML using LINQ to XML and finally create new XmlReader object
		var feed = SyndicationFeed.Load(XDocument.Parse(rssFeedAsString).CreateReader());
		// take the info from the firdst feed entry
		var firstFeedItem = feed.Items.FirstOrDefault();
		Console.WriteLine(firstFeedItem.Title.Text);
		Console.WriteLine(firstFeedItem.Links.FirstOrDefault().Uri.AbsoluteUri);
	}
	catch (Exception exception)
	{
		Console.WriteLine(exception.Message);
	}
