        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            Console.WriteLine("How many players?");
            int howManyPlayers = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < howManyPlayers; i++)
            {
                Console.WriteLine("Name the player");
                Player playa = new Player() { Name = Console.ReadLine() };
                players.Add(playa);
            }
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in players)
                {
                    // to avoid this repeating code, you could create a Round class
                    // populate the Arrow*x* properties in a loop
                    // and add the populated Round to the Player.
                    Console.WriteLine("Player {0} - Enter points 1 for round {1}", item.Name, i + 1);
                    int round1Input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Player {0} - Enter points 2 for round {1}", item.Name, i + 1);
                    int runda2Input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Player {0} - Enter points 3 for round {1}", item.Name, i + 1);
                    int runda3Input = Convert.ToInt32(Console.ReadLine());
                    item.Rounds.Add(new Round(round1Input, runda2Input, runda3Input));
                }
            }
            printAllPlayers(players);
        }
        static void printAllPlayers(List<Player> players)
        {
            Console.WriteLine("Printing {0} players ...", players.Count);
            foreach (Player player in players)
            {
                Console.WriteLine("Player: {0} \nScore: {1}", player.Name, player.TotalScore);
            }
            Console.ReadLine();
        }
    }
    class Round
    {
        public Round()
        {
        }
        public Round(int Arrow1, int Arrow2, int Arrow3)
        {
            arrow1 = Arrow1;
            arrow2 = Arrow2;
            arrow3 = Arrow3;
        }
        public int arrow1 { get; set; }
        public int arrow2 { get; set; }
        public int arrow3 { get; set; }
        public int Score
        {
            get
            {
                return arrow1 + arrow2 + arrow3;
            }
        }
    }
    class Player
    {
        public Player()
        {
            Rounds = new List<Round>();
        }
        public string Name { get; set; }
        public List<Round> Rounds { get; set; }
        public int TotalScore
        {
            get
            {
                int score;
                score = 0;
                // iterate through the player's Rounds, summing the Scores
                foreach (var r in Rounds)
                {
                    score += r.Score;
                }
                return score;
            }
        }
