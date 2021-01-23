    if (doc.DocumentNode.SelectNodes("//img[@usemap]") != null)
    {
    	HtmlNodeCollection imgs = doc.DocumentNode.SelectNodes("//img[@usemap]");
    	foreach (HtmlNode img in imgs)
    	{
    		img.ParentNode.RemoveChild(img);
    	}
    }
    
    if (doc.DocumentNode.SelectNodes("//map") != null)
    {
    	HtmlNodeCollection maps = doc.DocumentNode.SelectNodes("//map");
    	foreach (HtmlNode map in maps)
    	{
    		map.ParentNode.RemoveChild(map);
    	}
    }
    var newHtml = doc.DocumentNode.OuterHtml;
