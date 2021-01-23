    public class Team
    {
        public ObjectId Id { get; set; }
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string BadgeSmall { get; set; }
        public string BadgeLarge { get; set; }
        public string TeamImage { get; set; }
        public string Formation { get; set; }
    }
    public MongoCursor<Team> GetTeams()
    {
        return mongoDatabase.Provider.GetCollection<Team>("Teams").FindAll();
    }
