        public class Streams
        {
            public Dictionary<string, string> _links { get; set; }
            public Stream stream { get; set; }
        }
        public class Stream
        {
            public long _id { get; set; }
            public string game { get; set; }
            public int viewers { get; set; }
            public string created_at { get; set; }
            public Dictionary<string, string> _links { get; set; }
            public Preview preview { get; set; }
            public Channel channel { get; set; }
        }
        public class Channel
        {
            public Dictionary<string, string> _links { get; set; }
            public object background { get; set; }
            public object banner { get; set; }
            public string broadcaster_language { get; set; }
            public string display_name { get; set; }
            public string game { get; set; }
            public string logo { get; set; }
            public bool mature { get; set; }
            public string status { get; set; }
            public bool partner { get; set; }
            public string url { get; set; }
            public string video_banner { get; set; }
            public int _id { get; set; }
            public string name { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public int delay { get; set; }
            public int followers { get; set; }
            public string profile_banner { get; set; }
            public string profile_banner_background_color { get; set; }
            public int views { get; set; }
            public string language { get; set; }
        }
        public class Preview
        {
            public string small { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
            public string template { get; set; }
        }
