    XmlSerializer ser = new XmlSerializer(typeof(Game[]), 
                  new XmlRootAttribute("GameArray") { Namespace = "http://foo.bar" });
    var games = (Game[])ser.Deserialize(stream);
---
    public class Game
    {
        public string Id { set; get; }
        public string Title { set; get; }
    }
