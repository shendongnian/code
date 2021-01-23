        public class Result
        {
            public string id { get; set; }
            public string type { get; set; }
            public DateTime date { get; set; }
            public string title { get; set; }
        }
        public class Data
        {
            public IList<Result> result { get; set; }
        }
        public class MyJsonObject
        {
            public Data data { get; set; }
        }
