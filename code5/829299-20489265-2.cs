        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        public class Sitemap : IHttpHandler
        {
            private const string NAMESPACE = "http://www.sitemaps.org/schemas/sitemap/0.9";
    
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "text/xml";
                XmlDocument sitemapDocument = GetSitemapDocument();
                context.Response.Write(sitemapDocument.InnerXml);
            }
    
            #region Build sitemap document methods
            private XmlDocument GetSitemapDocument()
            {
                XmlDocument sitemapDocument = new XmlDocument();
                sitemapDocument.PreserveWhitespace = true;
                
                XmlDeclaration xmlDeclaration = 
                    sitemapDocument.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
                sitemapDocument.AppendChild(xmlDeclaration);
    
                XmlElement urlset = sitemapDocument.CreateElement("urlset", NAMESPACE);
                sitemapDocument.AppendChild(urlset);
    
                List<SitemapPage> urls = GetSitemapPages();
    
                foreach (SitemapPage sitemapPage in urls)
                {
                    XmlElement url = CreateUrlElement(sitemapDocument, sitemapPage);
                    urlset.AppendChild(url);
                }
                return sitemapDocument;
            }
    
            private XmlElement CreateUrlElement(XmlDocument sitemapDocument, 
                SitemapPage sitemapPage)
            {
                XmlElement url = sitemapDocument.CreateElement("url", NAMESPACE);
    
                XmlElement loc = CreateElementWithText(sitemapDocument, "loc", 
                    sitemapPage.Location);
                url.AppendChild(loc);
    
                if (sitemapPage.LastModificationDate.HasValue)
                {
                    //lastmod must be a string that comforms to the W3C Datetime format
                    string lastModValue = sitemapPage.LastModificationDate.Value.ToString(
                        "yyyy'-'MM'-'dd'T'HH':'mm':'ssK");
                    XmlElement lastmod = CreateElementWithText(
                        sitemapDocument, "lastmod", lastModValue);
                    url.AppendChild(lastmod);
                }
    
                if (!string.IsNullOrEmpty(sitemapPage.ChangeFrequency))
                {
                    XmlElement changefreq = CreateElementWithText(sitemapDocument, 
                        "changefreq", sitemapPage.ChangeFrequency);
                    url.AppendChild(changefreq);
                }
    
                if (sitemapPage.Priority.HasValue)
                {
                    XmlElement priority = CreateElementWithText(sitemapDocument,
                        "priority", sitemapPage.Priority.Value.ToString(
                            CultureInfo.CreateSpecificCulture("en-US")));
                    url.AppendChild(priority);
                }
    
                return url;
            }
    
            private XmlElement CreateElementWithText(
                XmlDocument document, string elementName, string text)
            {
                XmlElement element = document.CreateElement(elementName, NAMESPACE);
                
                XmlText elementValue = document.CreateTextNode(text);
                element.AppendChild(elementValue);
                
                return element;
            }
            #endregion
    
            private List<SitemapPage> GetSitemapPages()
            {
                List<SitemapPage> sitemapPages = new List<SitemapPage>();
                
                //Example implementation
                sitemapPages.Add(new SitemapPage("http://www.mydomain.com") 
                    { ChangeFrequency = "daily", LastModificationDate = DateTime.Now, Priority = 1f });
                sitemapPages.Add(new SitemapPage("http://www.mydomain.com/aPage.aspx") 
                    { ChangeFrequency = "daily", LastModificationDate = DateTime.Now, Priority = 0.8f });
                
                return sitemapPages;
            }
    
            private class SitemapPage
            {
                public SitemapPage(string location)
                {
                    Location = location;
                }
    
                public string Location { get; private set; }
                public DateTime? LastModificationDate { get; set; }
                public string ChangeFrequency { get; set; }
                public float? Priority { get; set; }
            }
    
            public bool IsReusable
            {
                get
                {
                    return true;
                }
            }
        }
