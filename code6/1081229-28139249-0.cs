    public void updateLocation(String woeid)
            {
                String query = String.Format("http://weather.yahooapis.com/forecastrss?w={0}", woeid);
    
                XmlDocument weatherData = new XmlDocument();
    
                weatherData.Load(query);
    
                XmlNode channel = weatherData.SelectSingleNode("rss").SelectSingleNode("channel");
                XmlNamespaceManager man = new XmlNamespaceManager(weatherData.NameTable);
                man.AddNamespace("geo", "http://www.w3.org/2003/01/geo/wgs84_pos#");
    
                latitude = channel.SelectSingleNode("item").SelectSingleNode("geo:lat", man).InnerText;
                
            }
