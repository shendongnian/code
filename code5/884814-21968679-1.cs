    HtmlNodeCollection link = doc.DocumentNode.SelectNodes("//*[@id='First']/span");
    if (link != null)
    {
    	foreach (HtmlNode item in link)
    	{
    		string name = item.InnerText;
    		string value = item.SelectSingleNode("./preceding-sibling::input[1]").Attributes["value"].Value;
    		Console.WriteLine(name);
    		Console.WriteLine(value);
    	}
    	Console.ReadLine();
    }
