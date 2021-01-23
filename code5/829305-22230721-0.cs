            var sitemap = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XProcessingInstruction("xml-stylesheet",
                    "type=\"text/xsl\" href=\"" + Url.AbsoluteAction("SitemapXsl", "Default") + "\""),
                new XElement(ns + "urlset",
                    new XAttribute(XNamespace.Xmlns + "sitemap", ns),
                    new XAttribute(XNamespace.Xmlns + "xhtml", xhtml), 
                    nodeList));
            Response.AddHeader("X-Robots-Tag","noindex");
            return Content(sitemap.Declaration+"\r\n"+sitemap, "text/xml");
