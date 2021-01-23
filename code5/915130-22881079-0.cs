    RenderTarget2D rTarget = null;
    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
               
        if (rTarget == null)
        {
            rTarget = new RenderTarget2D(Game.Graphics.GraphicsDevice,
                                            Game.Graphics.GraphicsDevice.PresentationParameters.BackBufferWidth,
                                            Game.Graphics.GraphicsDevice.PresentationParameters.BackBufferHeight,
                                            false,
                                            Game.Graphics.GraphicsDevice.PresentationParameters.BackBufferFormat,
                                            DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);
            
            Game.Graphics.GraphicsDevice.SetRenderTarget(rTarget);
            
            Game.Graphics.GraphicsDevice.Clear(Color.Black);
            
            SpriteBatch.Begin(); //new
    
            Game.SpriteBatch.Draw(ContentManager.Load<Texture2D>("tiles"), new Rectangle(0, 0, 100, 100), Color.White);
        
            SpriteBatch.End(); //new
            
            Game.Graphics.GraphicsDevice.SetRenderTarget(null);
        }
        
        GraphicsDevice.Clear(GameBackgroundColor);
            
        SpriteBatch.Begin();
            
        SpriteBatch.Draw(rTarget, new Rectangle(0, 0,400, 400), Color.White);
            
        //draw the character
        character.Draw(gameTime);
            
        SpriteBatch.End();
            
        base.Draw(gameTime);
    }
