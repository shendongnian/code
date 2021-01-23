    //Properties
    private Texture2D Texture { get; set; }
    private SoundEffect Sound { get; set; }
    private Rectangle Rectangle { get; set; }
    public Button(SoundEffect sound, Texture2D texture, Rectangle position)
    {
        Sound = sound;
        Texture = texture;
        Rectangle = position;
    }
    public void Update(GameTime gameTime, MouseState mouseState)
    {
          //If mouse is down and the rectangle contains the mouse point (Better for points than Intersect())
          if (mouseState.LeftButton == ButtonState.Pressed && Rectangle.Contains(new Point(mouseState.X,mouseState.Y))
          {
               Sound.Play()
          }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, rectangle, Color.White);
    }
