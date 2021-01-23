            var gameWorld = new GameWorld ();
            var stopwatch = Stopwatch.StartNew ();
            gameWorld.Update();
            for (var n = 0; n < 60;)
            {
                if ((int)(stopwatch.ElapsedMilliseconds / 1000) > n)
                {
                    gameWorld.PlayerMovement ();
                    gameWorld.Update ();
                    n = x;
                    Console.WriteLine ("{0}ms elapsed.", stopwatch.ElapsedMilliseconds);
                }
            }
