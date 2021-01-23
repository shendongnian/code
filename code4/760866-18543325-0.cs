    class Foo
    {
         public void LoadContent(ContentManager content)
         {
              Logo_Texture2d = content.Load<Texture2D>("Logo");
         }
    }
    public class Game1 : Game
    {
         //...
         protected override void LoadContent()
         {
              Foo.LoadContent(Content);
         }
    }
