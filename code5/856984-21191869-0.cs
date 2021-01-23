    bool readytofire = true;
    public override void Update()
    {
        KeyboardState newState = Keyboard.GetState();
        if (newState.IsKeyDown(Keys.Space) && readytofire)
        {
            bulletList.Add(new Bullet(content.Load<Texture2D>(@"bullet"), new Vector2(initialPos.X, initialPos.Y - 28), new Vector2(2, 4), spriteBatch));
        }
        readytofire = !newState.IsKeyDown(Keys.Space);
    }
