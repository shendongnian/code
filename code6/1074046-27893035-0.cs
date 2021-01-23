    var userList  = JsonConvert.DeserializeObject < Dictionary<string, User>>(json);
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public long revisionDate { get; set; }
        public int summonerLevel { get; set; }
    }
