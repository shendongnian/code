    class GameWorld {
        ...
        DateTime startTime;
        
        void Start() {
            startTime = DateTime.UtcNow;
        }
        
        void PrintCountdown() {
            DateTime currentTime = DateTime.UtcNow;
            TimeSpan gameRunTime = currentTime - startTime;
            int timeRemaining = 60 - gameRunTime.TotalSeconds();
            // Whatever code you have to print the countdown time
        }
        ...
    }
