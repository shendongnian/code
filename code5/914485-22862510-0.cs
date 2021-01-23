	HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
	doc.LoadHtml(stringContainingYourHtml);
	foreach (HtmlAgilityPack.HtmlNode txt in doc.DocumentNode.SelectNodes("//textarea")) {
		if ((txt.Attributes("questn-id") != null) && ! String.IsNullOrEmpty(txt.Attributes("questn-id").Value) {
			string txtVal = txt.Attributes("questn-id").Value.ToLower();
			// do whatever you want to do for validation here.
	}
}
	
