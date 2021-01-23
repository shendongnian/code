    using Sitecore;
    using Sitecore.Links;
    using Glass.Mapper.Sc.Fields;
    
    public static class LinkExtensions
    {
    	public static string GetLinkUrl(this Link link)
    	{
    		if (link != null)
    		{
    			if (link.Type == LinkType.External || link.Type == LinkType.Media)
    			{
    				return link.Url;
    			}
    			else if (link.Type == LinkType.Internal)
    			{
    				var target = Context.Database.GetItem(new ID(link.TargetId));
    
    				var urlOptions = UrlOptions.DefaultOptions;
    				urlOptions.AlwaysIncludeServerUrl = true;
    				urlOptions.SiteResolving = true;
    
    				return LinkManager.GetItemUrl(target, urlOptions);
    			}
    		}
    
    		return string.Empty;
    	}
    }
