        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            brick = Content.Load<Texture2D>("Whatever texture you want here");
            (int a = 0; a < brickXY.Length - 1; a++)
            {
                brickXY[a].X += (32 * a);
            }
        }
