	HtmlDocument doc = new HtmlDocument();
	doc.LoadHtml(source);
	var div = doc.DocumentNode.SelectSingleNode("//div[@id='first-tweet-wrapper']");
	if (div != null)
	{
		var links = div.Descendants("a")
						// you want only the link that has no other attributes than href
						.Where (l => String.IsNullOrEmpty(l.GetAttributeValue("class", "")))
						.FirstOrDefault();
		if (links != null)
		{
			// take the value of the attribute
			var link = links.GetAttributeValue("href", "");
			Console.WriteLine(link);
		}
	}
