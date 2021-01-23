    public class XmlSitemapResult : ActionResult
    {
        private XNamespace nsSitemap = "http://www.sitemaps.org/schemas/sitemap/0.9";
        private XNamespace nsXhtml = "http://www.w3.org/1999/xhtml";
    
        private IEnumerable<SitemapItem> _items;
    
        public XmlSitemapResult(IEnumerable<SitemapItem> items)
        {
            _items = items;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            string encoding = context.HttpContext.Response.ContentEncoding.WebName;
            XDocument sitemap = new XDocument(new XDeclaration("1.0", encoding, "yes"),
                 new XElement(nsSitemap + "siteMap", new XAttribute(XNamespace.Xmlns + "xhtml", nsXhtml),
                      from item in _items
                      select CreateItemElement(item)
                      )
                 );
    
            context.HttpContext.Response.ContentType = "application/xml";
            context.HttpContext.Response.Charset = encoding;
            context.HttpContext.Response.Flush();
            context.HttpContext.Response.Write(sitemap.Declaration + sitemap.ToString());
        }
    
        private XElement CreateItemElement(SitemapItem item)
        {
            XElement itemElement = new XElement(nsSitemap + "siteMapNode", new XElement(nsSitemap + "loc", item.Url.ToLower()));
    
            if (item.LastModified.HasValue)
                itemElement.Add(new XElement(nsSitemap + "lastmod", item.LastModified.Value.ToString("yyyy-MM-dd")));
    
            if (item.ChangeFrequency.HasValue)
                itemElement.Add(new XElement(nsSitemap + "changefreq", item.ChangeFrequency.Value.ToString().ToLower()));
    
            if (item.Priority.HasValue)
                itemElement.Add(new XElement(nsSitemap + "priority", item.Priority.Value.ToString(CultureInfo.InvariantCulture)));
    
            foreach (var alternateLink in item.AlternateLinks)
            {
                itemElement.Add(new XElement(nsXhtml + "link", 
                    new XAttribute("rel", "alternate"),
                    new XAttribute("hreflang", alternateLink.Language),
                    new XAttribute("href", alternateLink.Url)));
            }
    
            return itemElement;
        }
    }
