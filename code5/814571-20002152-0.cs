    class Title_Screen{
        //...
        public static ContentManager Content;
        Texture2D titleScreenPH;
    
        //...
        public static void Load(){
           titleScreenPH = Content.Load<Texture2D>(@"Images\TitleScreenPH");
        }
    }
