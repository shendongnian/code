    string json = @"{""yourname"": {
                    ""id"": 42728521,
                    ""name"": ""Your Name"",
                    ""profileIconId"": 27,
                    ""revisionDate"": 1397930999000,
                    ""summonerLevel"": 1
                    }}";
    var dict = JsonConvert.DeserializeObject<Dictionary<string, Summoner>>(json);
    var summoner = dict.First().Value;
    Console.WriteLine(summoner.id);
    Console.WriteLine(summoner.name);
    Console.WriteLine(summoner.summonerLevel);
