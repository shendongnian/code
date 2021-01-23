      static void Main (string[] args)
      {
            
            XmlDocument doc = new XmlDocument ();
            
            doc.Load ("http://xml.weather.yahoo.com/forecastrss?p=GMXX1791&u=c"); 
            //doc.Save ("test.xml");
            
            XmlNamespaceManager ns = new XmlNamespaceManager (doc.NameTable);
            ns.AddNamespace ("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");
            XmlNodeList lastBuildDate = doc.SelectNodes ("//rss/channel/lastBuildDate", ns);
            Console.WriteLine (lastBuildDate[0].InnerText);
            XmlNodeList nodescity = doc.SelectNodes ("//rss/channel/title", ns);
            foreach (XmlNode xnCity in nodescity)
            {
                Console.WriteLine (xnCity.InnerText);
            }
            
            XmlNodeList nodes = doc.SelectNodes ("//rss/channel/item/yweather:forecast", ns);
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine ("{0}: {1}, {2}C - {3}C",
                node.Attributes["day"].InnerText,
                node.Attributes["text"].InnerText,
                node.Attributes["low"].InnerText,
                node.Attributes["high"].InnerText);
            }
        }
    
