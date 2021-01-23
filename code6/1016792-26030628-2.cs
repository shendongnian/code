    public class Game1 : Microsoft.Xna.Framework.Game
    {
    // CLASSES
    Player myPlayer;
    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        myPlayer.ContentLoad(CoolContent);
    }
