    void Main()
    {
        string jsonString = "{'44542152': [{ 'queue': 'RANKED_SOLO_5x5', 'name': 'Elises Elite', 'entries': [{ 'leaguePoints': 0, 'isFreshBlood': false, 'isHotStreak': false, 'division': 'IV', 'isInactive': false, 'isVeteran': false, 'playerOrTeamName': 'Autism', 'playerOrTeamId': '44543152', 'wins': 11 }], 'tier': 'SILVER' }]}".Replace('\'','"');
    
        JObject jsonObject = JObject.Parse(jsonString);
        JArray jsonArray = jsonObject.Values().First() as JArray;
        var summonerRankInfo = jsonArray.First().ToObject<RootObject>();
    }
      
    public class Entry
    {
        public int leaguePoints { get; set; }
        public bool isFreshBlood { get; set; }
        public bool isHotStreak { get; set; }
        public string division { get; set; }
        public bool isInactive { get; set; }
        public bool isVeteran { get; set; }
        public string playerOrTeamName { get; set; }
        public string playerOrTeamId { get; set; }
        public int wins { get; set; }
    }
    public class RootObject
    {
        public string queue { get; set; }
        public string name { get; set; }
        public List<Entry> entries { get; set; }
        public string tier { get; set; }
    }
