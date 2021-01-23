                // TODO: Add your update logic here
            HandleInput(Keyboard.GetState());
            player.Update(gameTime);
            // delete from here
            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Block b in Blocks)
            {
                player = b.BlockCollision(player);
            }
            // place here
            camera.thing(player);
