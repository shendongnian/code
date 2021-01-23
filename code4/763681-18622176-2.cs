    public class Main
    {
        public static bool DrawAliveMario;
        RunMarioSprite runmariosprite;
        DeadMarioSprite deadmariosprite;
    
        protected override void Draw(GameTime gameTime)
        {
            //...
    
            // TODO: Add your drawing code here
            if (DrawAliveMario) runmariosprite.Draw(this.spriteBatch);
            else deadmariosprite.Draw(this.spriteBatch);
    
            base.Draw(gameTime);
        }
        
    }
