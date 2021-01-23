    public abstract class Sprites
    {
        public Texture2D SpriteTexture;
        public Rectangle SpriteRectangle;
        public SpriteTypes SpriteType;
        public Color SpriteColour;
        public bool SpriteAlive = false;
    
        public Sprites(Texture2D TextureIn, Rectangle RectangleIn)
        {
            SpriteTexture = TextureIn;
            SpriteRectangle = RectangleIn;
            SpriteType = SpriteTypes.Sprite;
            SpriteColour = Color.White;
        }
    
        // note the `abstract` keyword here,
        // which means "this method is to be implemented in child classes" 
        public abstract void Update();    
    }
    
    public class ChildSprites : Sprites
    {
         public override void Update()//note `override` keyword
         {
             // ...
         }
    }
