    public class Size
    {
        public string src { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string type { get; set; }
    }
    
    public class Likes
    {
        public int user_likes { get; set; }
        public int count { get; set; }
    }
    
    public class Item
    {
        public int id { get; set; }
        public int album_id { get; set; }
        public int owner_id { get; set; }
        public List<Size> sizes { get; set; }
        public string text { get; set; }
        public int date { get; set; }
        public Likes likes { get; set; }
    }
    
    public class RootObject
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }
