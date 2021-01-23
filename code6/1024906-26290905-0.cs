    using (var client = new WebClient())
    {
        api_return = client.DownloadString(api_call_key);
    }
    var foo = JsonConvert.DeserializeObject<Summoner>(api_return);
    Console.WriteLine(foo.id);
    Console.WriteLine(foo.name);
    Console.WriteLine(foo.summonerLevel);
    ..............
    }
    public class Summoner
    {
        public int id { get; set; }
        public string name { get; set; }
        public int summonerLevel { get; set; }
    }
