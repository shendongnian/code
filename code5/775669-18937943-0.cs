    using(var wc = new System.Net.WebClient()){
    	string html = wc.DownloadString("http://foo.com");
    	var doc = new HtmlAgilityPack.HtmlDocument();
    	doc.LoadHtml(html);
    	var el = doc.GetElementbyId("foo");
    	if(el != null)
    	{
    		var text = el.InnerText;
    		Console.WriteLine(text);
    	}
    }
