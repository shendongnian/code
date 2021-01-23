    public static void Main()
    {
    	HtmlNode.ElementsFlags.Remove("form");
    
    	var doc = new HtmlDocument();
    	doc.Load("HtmlPage1.html");
    
    	HtmlNode formNode = doc.DocumentNode.SelectNodes("//form")[0];
    	foreach (HtmlNode innode in formNode.Elements("input"))
    	{
    		Console.WriteLine(innode.OuterHtml);
    	}
    
    	Console.WriteLine("Press Enter to exit...");
    	Console.ReadLine();
    }
