    public class Player
    {
        public Player();
        public Player(Player original)
        {
            fname = original.fname;
            lname = original.lname;
        }
        public string fname{get; set;}
        public string lname{get; set;}
    }
    ...
    PlayerData playerData = GetPlayerStats();
    Player player = new Player(playerData);
