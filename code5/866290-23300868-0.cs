    public class RsssReader
    {
        public static IEnumerable<RSSS> GetRssFeed(string url)
        {
            XDocument xdoc;
                var feeds = from feed in xdoc.Descendants("item")
                            select new RSSS
                            {
                                Title = feed.Element("title").Value,
                                Link = feed.Element("link").Value,
                            };
                return feeds;
            }
        }
        public static IEnumerable<RSSS> GetMultipleFeeds(string searchTerm)
        {
            string urluno = "http://your/first/link";
            string url = "http://your/second/link";
            string url2 = "http://your/second/link";
            string urldos = "http://your/second/link";
           
            return GetRssFeed(urluno).Union(GetRssFeed(url).Union(GetRssFeed(url2).Union(GetRssFeed(urldos))));
        }
    } 
