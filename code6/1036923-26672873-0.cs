     public class Summary
        {
            public string ServiceName {get; set;}
            public string ProductType {get; set;}
        }
    
        public class Policy
        {
            public List<Summary> Summaries { get; set; }
        }
