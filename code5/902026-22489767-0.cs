    class GameWorld {
        ...
        DateTime startTime;
        
        void Start() {
            startTime = DateTime.Now();
        }
        
        void PrintCountdown() {
            DateTime currentTime = DateTime.Now();
            TimeSpan gameRunTime = currentTime - startTime;
            int timeRemaining = 60 - gameRunTime.TotalSeconds();
            // Whatever code you have to print the countdown time
        }
        ...
    }
