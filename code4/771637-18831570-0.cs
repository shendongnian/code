    var result = JsonConvert.DeserializeObject<Root>(json);
----
    public class MyImage
    {
        public string item_id { get; set; }
        public string image_id { get; set; }
        public string src { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string credit { get; set; }
        public string caption { get; set; }
    }
    public class MyVideo
    {
        public string item_id { get; set; }
        public string video_id { get; set; }
        public string src { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string type { get; set; }
        public string vid { get; set; }
    }
    public class MyListItem
    {
        public string item_id { get; set; }
        public string resolved_id { get; set; }
        public string given_url { get; set; }
        public string given_title { get; set; }
        public string favorite { get; set; }
        public string status { get; set; }
        public string resolved_title { get; set; }
        public string resolved_url { get; set; }
        public string excerpt { get; set; }
        public string is_article { get; set; }
        public string has_video { get; set; }
        public string has_image { get; set; }
        public string word_count { get; set; }
        public Dictionary<string, MyImage> images; // <---
        public Dictionary<string, MyVideo> videos; // <---
    }
    public class Root
    {
        public int status;
        public Dictionary<string, MyListItem> list; // <---
    }
