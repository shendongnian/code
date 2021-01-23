	// Read the feed
	while (await feedReader.Read())
	{
		if (feedReader.ElementType == SyndicationElementType.Item)
		{
			// Read the item as generic content
			ISyndicationContent content = await feedReader.ReadContent();
			// Parse the item if needed (unrecognized tags aren't available)
			// Utilize the existing parser
			ISyndicationItem item = parser.CreateItem(content);
			string urlImage = GetThumbailsImage(content, url);
			rssNewsItems.Add(item.ConvertToNewsItem(urlImage));
		}
	}
    private string GetThumbailsImage(ISyndicationContent content, string source)
	{
		// Get <media:thumbnail> field
		ISyndicationContent customElement = content.Fields.FirstOrDefault(f => f.Name == "thumbnail");
		var thimbUrl = customElement.Attributes.FirstOrDefault(a => a.Name == "url");
		return thimbUrl?.Value;
	}
