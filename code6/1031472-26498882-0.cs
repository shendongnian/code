    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Color { get; set; }
        public int[] Attribs { get; set; }
    }
    ...
    List<Player> myPlayers = new List<Player>();
    Player joe = new Player();
    joe.Name = "Joe";
    joe.Score = 25;
    joe.Color = "red;
    joe.Attribs = new int[] { 0, 1, 2, 3, 4 };;
    myPlayers.Add(joe);
