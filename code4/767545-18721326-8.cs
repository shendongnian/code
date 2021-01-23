    private void button1_Click(object sender, EventArgs e)
    {
    	bool found = true;
    	while (found)
    	{
    		if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
    		{
    			found = ClickLoadMoreButton();
    			Application.DoEvents();
    		}
    	}
    }
    
    private bool ClickLoadMoreButton()
    {
    	var buttons = webBrowser1.Document.GetElementsByTagName("button");
    	foreach (HtmlElement el in buttons)
    	{
    		var firstChild = el.FirstChild;
    		if (firstChild != null)
    		{
    			if (!string.IsNullOrEmpty(firstChild.InnerText))
    			{
    				if (firstChild.InnerText.ToLower().Replace(" ", string.Empty).Equals("loadmore"))
    				{
    					el.InvokeMember("click");
    					return true;
    				}
    			}
    		}
    	}
    	return false;
    }
