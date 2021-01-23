    public class Data
        {
            public Users[] users { get; set; }
        }
    
        public class Users
        {
            public Image image { get; set; }
        }
    
        public class Image
        {
            public StandardUrl standardUrl { get; set; }
        }
    
        public class StandardUrl
        {
            public string url { get; set; }
        }
