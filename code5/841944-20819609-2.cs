    public class KeyValue
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public int summonerLevel { get; set; }
        public long revisionDate { get; set; }
    }
    static void Main(string[] args)
    {
        var strJSON = "{\"id\":34379899,\"name\":\"Revelation22\",\"profileIconId\":547,\"summonerLevel\":30,\"revisionDate\":1387913628000}";
        var serializer = new JavaScriptSerializer();
   
        var keyValue = serializer.Deserialize<KeyValue>(strJSON);
        var id = keyValue.id;
        var name = keyValue.name;
        var level = keyValue.summonerLevel;
        Console.WriteLine("Summoner name:{0}, Id:{1}, Level:{2}", name, id, level);
        Console.Read();
    }
