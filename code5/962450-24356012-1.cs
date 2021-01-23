    public class MyGame : Microsoft.Xna.Framework.Game {
       public static ContentManager ContentManager;
       //...
       public MyGame( ) {
            //...
            ContentManager = Content;
        }
        protected override void Initialize(){
            // TODO: Add your initialization logic here
 
            base.Initialize();
        }
        
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
 
            // TODO: use this.Content to load your game content here
            //...
            this.InitializeAfterLoadingContent();            
        }
       
        //you can call it however you want
        private void InitializeAfterLoadingContent(){
            //initialize your non-graphical resources by using the content info you need,
            //like the width and height of a texture you loaded
        }
        //...
    }
