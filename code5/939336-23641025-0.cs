     class Player
            {
                public string Name { get; set; }
                public int goals { get; set; }
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Enter the amount of players");
                int amount = int.Parse(Console.ReadLine());
                List<Player> _players = new List<Player>();
                for (int i = 0; i < amount; i++)
                {
                    Player objPlayer = new Player();
                    Console.WriteLine("Enter a players name");
                    objPlayer.Name = Console.ReadLine();
                    Console.WriteLine("Enter how many goals they have score this season");
                    objPlayer.goals  = int.Parse(Console.ReadLine());
                    _players.Add(objPlayer);
    
                }
    
                int maxgoals = _players.Max(t => t.goals);
                var maxplayer = _players.FirstOrDefault(t => t.goals == maxgoals).Name;
    
                int mingoals = _players.Min(t => t.goals);
                var minplayer = _players.FirstOrDefault(t => t.goals == maxgoals).Name;
    
                var average = _players.Sum(t=>t.goals)/amount;
    
                Console.WriteLine("The top player is {0} with a score of {1}", maxplayer, maxgoals);
                Console.WriteLine("");
                Console.WriteLine("The bottom player is {0} with a score of {1}", minplayer, mingoals);
                Console.WriteLine("");
                Console.WriteLine("The average goals scored is {0}", average);
                Console.ReadLine();
            }
