    using System;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var json = @"{'user': {
                            'country':'US',
                            'email':'testapi@example.com',
                            'first_name':'Test',
                            'last_name':'API',
                            'phone':null,
                            'zip':null,
                            'login_url':'https://new.site.com/xlogin/12325/abd9832cd92'
                            }
                        }";
    
                RootObject userObj = JsonConvert.DeserializeObject<RootObject>(json.ToString());
    
            }
        }
    
    
        //generated with http://json2csharp.com/
        public class User
        {
            public string country { get; set; }
            public string email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public object phone { get; set; }
            public object zip { get; set; }
            public string login_url { get; set; }
        }
    
        public class RootObject
        {
            public User user { get; set; }
        }
    }
