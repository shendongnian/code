    HtmlNodeCollection link = doc.DocumentNode.SelectNodes("//*[@id='First']/span");
    if (link != null)
    {
    	foreach (HtmlNode item in link)
    	{
    		string name = item.InnerText;
    		Console.WriteLine(name);
    	}
    	Console.ReadLine();
    }
