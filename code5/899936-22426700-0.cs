        public class RootObject
        {
            public Logined logined { get; set; } //not a collection
        }
        foreach (Logined m in json.logined) //json.logined is a single object (not a collection)
        {
        }
