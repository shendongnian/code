    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Points { get; set; }
    }
    public class TeamManager
    {
        List<Player> players;
        public TeamManager()
        {
            this.players = new List<Player>();
        }
        public void Add(Player player)
        {
            this.players.Add(player);
        }
        public bool Delete(Player player)
        {
            if (this.players.Contains(player))
                return this.players.Remove(player);
            else
                return false;
        }
    }
