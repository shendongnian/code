    internal class Program
    {
        public class PlayerData
        {
            public string Name { get; set; }
            public string BallonDor { get; set; }
            public string Country { get; set; }
            public string MarketValue { get; set; }
            public string CurrentClub { get; set; }
        }
        private static void Main(string[] args)
        {
            var sample = new[]
            {
                new
                {
                    Player_Name = "",
                    Country = "",
                    Personal_Honours = new
                    {
                        Ballon_DOr = "",
                    },
                }
            };
            dynamic json = JsonConvert.DeserializeObject(@"[
    {
      ""Player_Name"": ""Zlatan Ibrahimovic"",
      ""Country"": ""Sweeden"",
    },
    {
    ""Player_Name"": ""Pavel Nedved"",
     ""Country"": ""Czech Republic"",
      ""Personal_Honours"": {
      ""Ballon_DOr"": ""One"",
    },
    }
    ]", sample.GetType());
            var dataList = new List<PlayerData>();
            foreach (var data in json)
            {
                dataList.Add(
                    new PlayerData
                    {
                        Name = data.Player_Name,
                        Country = data.Country,
                        BallonDor = data.Personal_Honours == null ? null : data.Personal_Honours.Ballon_DOr
                    });
            }
        }
    }
