	public static void wina()
	{            
		WebBrowser webBrowser1 = new WebBrowser();
		webBrowser1.Navigate("https://www.winamax.fr/paris-sportifs#/live");
		webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(recup(webBrowser1));
	}
	public static void tryrecup(WebBrowser e)
	{
		StringBuilder sb2 = new StringBuilder();
		foreach (HtmlElement elm in e.Document.All)
			if (elm.GetAttribute("className") == "contestant-name")
				sb2.Append(elm.InnerHtml);
		HtmlDocument doc = e.Document;
		doc.Body.InnerHtml = sb2.ToString();
	}
