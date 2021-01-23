    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public class Entry
    {
        public string PlayerOrTeamId { get; set; }
        public string PlayerOrTeamName { get; set; }
        public string Division { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public bool IsHotStreak { get; set; }
        public bool IsVeteran { get; set; }
        public bool IsFreshBlood { get; set; }
        public bool IsInactive { get; set; }
    }
    
    public class Item
    {
        public string Name { get; set; }
        public string Tier { get; set; }
        public string Queue { get; set; }
        public List<Entry> Entries { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            string returnedData =
            @"{
                ""43086"": [{
                    ""name"": ""Karthus's Brigands"",
                    ""tier"": ""SILVER"",
                    ""queue"": ""RANKED_SOLO_5x5"",
                    ""entries"": [{
                        ""playerOrTeamId"": ""43086"",
                        ""playerOrTeamName"": ""Testy Test"",
                        ""division"": ""IV"",
                        ""leaguePoints"": 77,
                        ""wins"": 130,
                        ""isHotStreak"": false,
                        ""isVeteran"": true,
                        ""isFreshBlood"": false,
                        ""isInactive"": false
                    }]
                }]
            }";
            var leagueStats = JsonConvert.DeserializeObject<Dictionary<int, Item[]>>(returnedData);
            Console.WriteLine(leagueStats.Count);
        }
    }
