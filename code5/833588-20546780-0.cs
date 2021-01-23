    var root  = JsonConvert.DeserializeObject<RootObject>(data);
---
    public class Next
    {
        public int nr { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public int needed { get; set; }
        public int curr { get; set; }
        public int relNeeded { get; set; }
        public int relCurr { get; set; }
        public double relProg { get; set; }
    }
    public class Rank
    {
        public int nr { get; set; }
        public string imgLarge { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public int needed { get; set; }
        public Next next { get; set; }
    }
    public class Player
    {
        public int id { get; set; }
        public string game { get; set; }
        public string plat { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
        public long dateCheck { get; set; }
        public long dateUpdate { get; set; }
        public long dateCreate { get; set; }
        public string lastDay { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
        public Rank rank { get; set; }
        public int score { get; set; }
        public int timePlayed { get; set; }
        public string uId { get; set; }
        public string uName { get; set; }
        public string uGava { get; set; }
        public long udCreate { get; set; }
        public string blPlayer { get; set; }
        public string blUser { get; set; }
        public bool editable { get; set; }
        public bool viewable { get; set; }
        public bool adminable { get; set; }
        public bool linked { get; set; }
    }
    public class RootObject
    {
        public Player player { get; set; }
    }
    
