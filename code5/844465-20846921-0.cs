    if (game.KeyboardManager.isKeyDown(left))
                {
                    Console.WriteLine("test");
                    bPause = false;
                    if(playerID == 1)
                    {
                    this.Presentation.SpriteEffects = SpriteEffects.FlipHorizontally;
                    }
                    else if(playerID == 2)
                    {
                        this.Presentation.SpriteEffects = SpriteEffects.FlipHorizontally;
                    }
                    this.Transform.MoveIncrement += -this.Transform.Look * timeBetweenUpdates;
                    Console.WriteLine((-this.Transform.Look * timeBetweenUpdates));
                    this.Transform.IsMoved = true;
                }
