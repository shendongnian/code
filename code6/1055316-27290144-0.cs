    private void GetWebpage(string url)
    {
    	WebBrowser browser = new WebBrowser();
    	browser.Navigate(url);
    	browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
    			
    }
    
    void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    	var browser = (WebBrowser)sender;
    	var client = new WebClient();
    	foreach (var img in browser.Document.Images)
    	{
    		var image = img as HtmlElement;
    		var src = image.GetAttribute("src").TrimEnd('/');
    		if (!Uri.IsWellFormedUriString(src, UriKind.Absolute))
    		{
    			src = string.Concat(browser.Document.Url.AbsoluteUri, "/", src);
    		}
    		
    		//Append any path to filename as needed
    		var filename = new string(src.Skip(src.LastIndexOf('/')+1).ToArray());
    		File.WriteAllBytes(filename, client.DownloadData(src));
    	}
    }
