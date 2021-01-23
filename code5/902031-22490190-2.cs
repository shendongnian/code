            var gameWorld = new GameWorld ();
            var stopwatch = Stopwatch.StartNew ();
            gameWorld.Update();
            while (stopwatch.ElapsedMilliseconds < 60000)
            {
                gameWorld.PlayerMovement();
                gameWorld.Update();
            }
