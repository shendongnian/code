    public class Player_Sprite //This class deals with drawing the players sprite and animations
    {
        public Rectangle player;
        public Texture2D playerAttack, playerWalk; //PLAYER TEXTURES
        public Player_Sprite()
        {
        }
        // .. methods removed for brevity
        public void Draw(SpriteBatch spriteBatch, Player_Movement pmove)
        {
            spriteBatch.Draw(playerWalk, pmove.position, new Rectangle(0, 0, 64, 64), Color.White);
        }
    }
