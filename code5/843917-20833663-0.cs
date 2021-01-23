     public class data
        {
            public itemWithlink Transaction { get; set; }
            public itemWithlink Block { get; set; }
            public itemWithlink ApproxTime { get; set; }
            public itemWithlink Amount { get; set; }
            public itemWithlink Balance { get; set; }
            public itemWithlink Currency { get; set; }
        }
    
        public class itemWithlink
        {
            public string numberOrname { get; set; }
            public string link { get; set; }
        }
