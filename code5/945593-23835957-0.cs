    public class Entity
    {
        public string text { get; set; }
        public string id { get; set; }
    }
    public class RootObject
    {
        public string type { get; set; }
        public string id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public UserData userData { get; set; }
        public string cssClass { get; set; }
        public string bgColor { get; set; }
        public string color { get; set; }
        public int stroke { get; set; }
        public int alpha { get; set; }
        public int radius { get; set; }
        public string name { get; set; }
        public List<Entity> entities { get; set; }
    }
