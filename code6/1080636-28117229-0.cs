    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            var jsonOne = "{ websites: \"http://www.google.com\" }";
            var jsonMany = "{ websites: [ \"http://www.google.com\", \"http://www.whatever.com\" ] }";
            var userOne = JsonConvert.DeserializeObject<User>(jsonOne);
            var userMany = JsonConvert.DeserializeObject<User>(jsonMany);
            Debug.WriteLine(":: One ::");
            Print(userOne);
            Debug.WriteLine(":: Many ::");
            Print(userMany);
        }
        static void Print(User user)
        {
            if(user.websites is string)
            {
                Debug.WriteLine("This user has a single website: {0}", user.websites);
            }
            if (user.websites is JArray)
            {
                Debug.WriteLine("This user has following websites:");
                foreach (var website in (JArray)user.websites)
                    Debug.WriteLine(website);
            }
        }
    }
    public class User
    {
        public object websites { get; set; }
    }
