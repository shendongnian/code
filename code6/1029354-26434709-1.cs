        public class From
        {
            public string id { get; set; }
            public string name { get; set; }
            public string category { get; set; }
        }
        public class Post
        {
          public string id { get; set; }
          public From from { get; set; }
          public string message { get; set; }
          public string picture { get; set; }
          public Dictionary<string, Like[]> likes { get; set; }
        } 
        public class Like
        {
            public string id { get; set; }
            public string name { get; set; }
        }
