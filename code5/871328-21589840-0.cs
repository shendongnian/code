    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace StackOverflowQ21588436
    {
        public class Example
        {
            private const string XML =
    @"<?xml version=""1.0"" encoding=""utf-8""?>
    <Advertisements>
        <Ad>
            <ImageUrl>http://example.com/example.jpg</ImageUrl>
            <url>http://example.com</url>
        </Ad>
        <Ad>
            <ImageUrl>http://example.com/example2.jpg</ImageUrl>
            <url>http://example.com/2.html</url>
        </Ad>
    </Advertisements>";
            public static IList<Advertisement> GetAdvertisements()
            {
                var xmlDocument = XDocument.Parse(XML); // or XDocument.Load(url)
                var adXmlNodes = xmlDocument.Element("Advertisements").Elements("Ad");
                var adList = adXmlNodes.Select(xmlNode => new Advertisement {
                    ImageUrl = xmlNode.Element("ImageUrl").Value,
                    Href = xmlNode.Element("url").Value
                }).ToList();
                return adList;
            }
        }
        public class Advertisement
        {
            public string ImageUrl { get; set; }
            public string Href { get; set; } // named 'Href' to show property names don't have to match XML
        }
    }
