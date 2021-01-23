    public class Map 
    {
         public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice, Game1 game)
         {
             switch (currentLevel) 
             { 
                  case 1:
                       texture1 = content.Load<Texture2D>("skyLine");
                       song = content.Load<Song>("music");
                       game.Window.Title = "Level 1";
                       MediaPlayer.Play(song);
                    break;
           }
        }
    }
