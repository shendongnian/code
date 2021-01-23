        public class KeyValue
        {
            public int id { get; set; }
            public string name { get; set; }
            public int profileIconId { get; set; }
            public int summonerLevel { get; set; }
            public int revisionDate { get; set; }
        }
        static void Main(string[] args)
        {
            var strJSON = "{\"id\":34379899,\"name\":\"Revelation22\",\"profileIconId\":547,\"summonerLevel\":30,\"revisionDate\":1387913628000}";
            var serializer = new JavaScriptSerializer();
            var keyValueLookup = serializer.Deserialize<IDictionary<string, object>>(strJSON);
            var id = (int)keyValueLookup["id"];
            var name = (string)keyValueLookup["name"];
            var level = (int)keyValueLookup["summonerLevel"];
            Console.WriteLine("Summoner name:{0}, Id:{1}, Level:{2}", name, id, level);
            Console.Read();
        }
