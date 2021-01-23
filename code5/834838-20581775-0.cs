	List<string> AllowedTags = new List<string>() { "br", "a" };
	HtmlDocument goodDoc = new HtmlDocument();
	goodDoc.LoadHtml("<a href='asdf'>asdf</a><br /><a href='qwer'>qwer</a>");
	bool containsBadTags = goodDoc.DocumentNode	.Descendants()
												.Where(node => node.NodeType == HtmlNodeType.Element)
												.Select(node => node.Name)
												.Except(AllowedTags)
												.Any();
	HtmlDocument badDoc = new HtmlDocument();
	badDoc.LoadHtml("<a href='asdf'><b>asdf</b></a><br /><a href='qwer'>qwer</a>");
	containsBadTags = badDoc.DocumentNode	.Descendants()
											.Where(node => node.NodeType == HtmlNodeType.Element)
											.Select(node => node.Name)
											.Except(AllowedTags)
											.Any();
													
