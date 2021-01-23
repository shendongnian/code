    Texture2d snaketexture;
    protected override void LoadContent()
    {
       snaketexture = Content.Load<Texture2D>(@"Textures/block");
    }
    protected override void Update(GameTime gameTime)
    {
       snake.Add(new snakeunits(snaketexture, new Vector2(100, 100), 10, new Vector2(0, 10)))
    }
