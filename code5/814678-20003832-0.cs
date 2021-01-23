        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1080;   //Height
            graphics.PreferredBackBufferWidth = 1920;  //Width
            graphics.IsFullScreen = true;    //Fullscreen On/off
            graphics.ApplyChanges();   //Execute Changes!!!IMPORTANT!!!
        }
