    class Program {
        static void Main(string[] args) {
            //Create firstPlayer
            Player firstPlayer = new Player {
                PlayerId = 1,
                DisplayName = "Goober",
                LastName = "Smith"
            };
            // Create secondPlayer
            Player secondPlayer = new Player {
                PlayerId = 2,
                DisplayName = "Destructor",
                LastName = "Henry"
            };
            // Create game instance
            Game currentGame = new Game();
            // Add players to game
            currentGame.AddPlayerToGame(firstPlayer);
            currentGame.AddPlayerToGame(secondPlayer);
            // Player scores a point
            secondPlayer.CurrentScore++;
            // Player clicks LeaveGame, etc.
            currentGame.PlayerLeavesGame(firstPlayer);
        }
    }
    
    public class Player {
        public int PlayerId { get; set; } // I assume the same as player numbers
        public string DisplayName { get; set; }
        public string LastName { get; set; }
        public int CurrentScore { get; set; }
    }
    public class Game {
        private static readonly int MAXPLAYERS = 10;
        public Game() {
            Players = new List<Player>();
        }
        public List<Player> Players { get; private set; }
        private int _PlayerCount = 0;
        public int PlayerCount {
            get {
                return _PlayerCount;
            }
            set {
                _PlayerCount = value;
            }
        }
        /// <summary>
        /// Tries to add a player to the game
        /// </summary>
        /// <param name="playerThatJoinedGame"></param>
        /// <returns>True if the player was added and the game wasn't full</returns>
        public bool AddPlayerToGame(Player playerThatJoinedGame) {
            if (PlayerCount < MAXPLAYERS) {
                Players.Add(playerThatJoinedGame);
                PlayerCount++;
                return true;
            }
            else {
                return false;
            }
            
            
        }
        /// <summary>
        /// Removes a player from the game
        /// </summary>
        /// <param name="playerThatQuit">The leaving player</param>
        public void PlayerLeavesGame(Player playerThatQuit) {
            // Removes the player from the game
            Players.Remove(playerThatQuit);
            PlayerCount--;
        }
    }
