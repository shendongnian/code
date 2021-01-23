        public class UserInfo
        {
            public string service_name { get; set; }
            public string uid { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
            public string Contact { get; set; }
            public object Mutual_friend { get; set; }
            public object Direct { get; set; }
            public string Miles { get; set; }
        }
        public class ResultSearch
        {
            public string service { get; set; }
            public List<UserInfo> user_info { get; set; }
        }
        public class RootObjectSearch
        {
            public string flag { get; set; }
            public string message { get; set; }
            public List<ResultSearch> result { get; set; }
        }
