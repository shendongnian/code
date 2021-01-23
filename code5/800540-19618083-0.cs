    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        // Opening Screen Textures
        test = Content.Load<Texture2D>("test");
        //LOAD but DONT PLAY sound
        backgroundSong = Content.Load<SoundEffect>("Call to Adventure");
        backgroundSongInstance = backgroundSong.CreateInstance();
        backgroundSongInstance.IsLooped = true;
        //Rest of code cut out for example!
    }
