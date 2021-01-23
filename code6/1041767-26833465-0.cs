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
            currentGame.Players.Add(firstPlayer);
            currentGame.Players.Add(secondPlayer);
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
        public Game() {
            Players = new List<Player>();
        }
        public List<Player> Players { get; set; }
        /// <summary>
        /// Removes a player from the game
        /// </summary>
        /// <param name="playerThatQuit">The leaving player</param>
        public void PlayerLeavesGame(Player playerThatQuit) {
            // Removes the player from the game
            Players.Remove(playerThatQuit);
        }
    }
