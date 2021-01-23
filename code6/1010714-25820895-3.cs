    protected override void Draw(GameTime gameTime)
    {
        var sprite = new SpriteBatch(this.GraphicsDevice);
        sprite.Begin();
    
        sprite.Draw(this.myTexture,
                        new Rectangle(10, 50, // position: x and y coordiantes in pixels
                                       /* width and height below
                                                - do not remeber order: */ 
                                      25,  25),
                        Color.White);
                        
        sprite.End();
        base.Draw(gameTime);
    }
