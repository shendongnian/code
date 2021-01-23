    case PlayGame:
            Console.Clear();
            GameWorld gameWorld = new GameWorld();
            gameWorld.Update();
            //Timer to ping you every second
            Timer aTimer = new Timer
            {
                Interval = 1000,    //change this to fit your needs
                Enabled = true
            };
             aTimer.Elapsed+=this.OnTimedEvent;
            while (gameWorld.GameState == GameState.Runs)
            {
                gameWorld.PlayerMovement();
                gameWorld.Update();
            }
