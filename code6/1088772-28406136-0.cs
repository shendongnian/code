        public class Box
        {
            public string id { get; set; }
            public string value { get; set; }
        }
        public class Level2
        {
            public string id { get; set; }
            public List<Box> Box { get; set; }
        }
        public class Level1
        {
            public List<Level2> Level2 { get; set; }
        }
        public class RootObject
        {
            public Level1 Level1 { get; set; }
        }
