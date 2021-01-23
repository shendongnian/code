    public class phaxioResponse
        {
            public string success { get; set; }
            public string message { get; set; }
            public Dictionary<int,areaCode> data { get; set; }
        
            public class areaCode
            {
                public string city { get; set; }
                public string state { get; set; }
            }
        }
