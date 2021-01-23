    public class Game
    {
        private IGameStrategy _strategy;
        // Constructor injection
        public Game(IGameStrategy strategy)
        {
            _strategy = strategy;
        }
        // Things common to all types of games go here...
    }
