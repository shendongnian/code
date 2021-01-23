    public sealed class HtmlTextExtractor
    {
    	private readonly string m_html;
    	
    	public HtmlTextExtractor(string html)
    	{
    		m_html = html;
    	}
    	
    	public IEnumerable<string> GetTextBlocks()
    	{
    		var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(m_html);
    
    		var text = new List<string>();
    		WalkNode(htmlDocument.DocumentNode, text);
    		
    		return text;
    	}
    	
    	private void WalkNode(HtmlNode node, List<string> text)
    	{
    		switch (node.NodeType)
    		{
                    case HtmlNodeType.Comment:
                        break; // Exclude comments?
    
                    case HtmlNodeType.Document:
                    case HtmlNodeType.Element:
    					{
    						if (node.HasChildNodes)
    						{					
    							foreach (var childNode in node.ChildNodes)
    								WalkNode(childNode, text);
    						}
    					}
                        break;
    					
    			case HtmlNodeType.Text:
    				{
    					var html = ((HtmlTextNode)node).Text;
    					if (html.Length <= 0)
    						break;
    					
    					var cleanHtml = HtmlEntity.DeEntitize(html).Trim();
    					if (!string.IsNullOrEmpty(cleanHtml))
    						text.Add(cleanHtml);
    				}
    				break;
    		}
    	}
    }
