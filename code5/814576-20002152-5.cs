    public class Game1 : Microsoft.Xna.Framework.Game{
        //...
    
        public Game1(){
            //...
            Title_Screen.Content = Content;
        }
        
        protected override void LoadContent(){
            //...
            Title_Screen.Load();
        }
    }
