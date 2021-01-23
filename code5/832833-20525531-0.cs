    [XmlRoot("rss")]
    public class RssRoot
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }
    public class Channel
    {
        [XmlElement("item")]
        public Item Item { get; set; }
        // other attributes
    }
    public class Item
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("forecast", Namespace="http://xml.weather.yahoo.com/ns/rss/1.0")]
        public List<Forecast> Forecasts { get; set; }
        // other attributes
    }
    public class Forecast
    {
        [XmlAttribute("text")]
        public string Text { get; set; }
        // other attributes
    }
