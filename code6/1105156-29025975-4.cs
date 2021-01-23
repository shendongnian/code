    public class MyClass
    {
        public class Result
        {
            public string name { get; set; }
            public string score { get; set; }
            public string url { get; set; }
            public string rlsdate { get; set; }
            public string rating { get; set; }
            public string summary { get; set; }
            public string platform { get; set; }
        }
        public class RootObject
        {
            public List<Result> results { get; set; }
        }
    }
