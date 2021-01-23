        public override void Update(GameTime gameTime)
        {
            position += speed * direction;
            if (animation != null)
                animation.Update();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            Game1 g = (Game1)Game;
            g.SpriteBatch.Draw(texture, position, Color.White);
            if (animation != null)
                g.SpriteBatch.Draw(animation.GiveTexture(), position2, Color.CornflowerBlue);
            base.Draw(gameTime);
        }
