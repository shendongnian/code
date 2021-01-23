    class Team : IEnumerable<Player>
    {
        private readonly List<Player> playerList;
        public Team()
        {
            playerList = new List<Player>();
        }
        public Enumerator GetEnumerator()
        {
            return playerList.GetEnumerator();
        }
        ...
    }
    class Player
    {
        ...
    }
