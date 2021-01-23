    public class Links
    {
        public string next { get; set; }
        public string self { get; set; }
    }
    
    public class Links2
    {
        public string self { get; set; }
    }
    
    public class Links3
    {
        public string stream_key { get; set; }
        public string self { get; set; }
        public string videos { get; set; }
        public string commercial { get; set; }
        public string chat { get; set; }
        public string features { get; set; }
    }
    
    public class Channel
    {
        public object banner { get; set; }
        public int _id { get; set; }
        public string url { get; set; }
        public object mature { get; set; }
        public List<object> teams { get; set; }
        public object status { get; set; }
        public object logo { get; set; }
        public string name { get; set; }
        public object video_banner { get; set; }
        public string display_name { get; set; }
        public string created_at { get; set; }
        public int delay { get; set; }
        public object game { get; set; }
        public Links3 _links { get; set; }
        public string updated_at { get; set; }
        public object background { get; set; }
    }
    
    public class Follow
    {
        public string created_at { get; set; }
        public Links2 _links { get; set; }
        public Channel channel { get; set; }
    }
    
    public class RootObject
    {
        public Links _links { get; set; }
        public List<Follow> follows { get; set; }
    }
