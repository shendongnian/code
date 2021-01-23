    var buttons = webBrowser1.Document.GetElementsByTagName("button");
    			foreach (HtmlElement el in buttons)
    			{
    				var firstChild = el.FirstChild;
    				if(firstChild != null)
    				{
    					if (!string.IsNullOrEmpty(firstChild.InnerText))
    					{
    						if (firstChild.InnerText.ToLower().Replace(" ", string.Empty).Equals("loadmore"))
    						{
    							el.InvokeMember("click");
    						}
    					}
    				}
    			}
