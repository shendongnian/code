    using System;
    using System.ServiceModel.Syndication;
    using System.Xml;
    namespace RSSFeed
    {
        public class Program
        {
            static void Main(string[] args)
            {
                // URL from the site you need (RSS Feed in XML please).
                String url = "http://www.medicalnewstoday.com/rss/abortion.xml";
                // Create XML Reader.
                using (XmlReader xmlReader = XmlReader.Create(url, new XmlReaderSettings() { DtdProcessing = DtdProcessing.Ignore }))
                {
                    // Load The Feed.
                    SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
                    // through the list.
                    foreach (SyndicationItem item in syndicationFeed.Items)
                    {
                        // You can use a lot of information here todo what you need.
                        // TODO...
                        // Examples
                        String subject = item.Title.Text;
                        String summary = item.Summary.Text;
                    }
                    xmlReader.Close();
                }
            }
        }
    }
