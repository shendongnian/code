    void Draw()
    {
        List<RenderTarget2D> targetList = new List<RenderTarget2D>();
        engine.Draw(texture, targetList);
        engine.Draw(light, targetList);
        //Tell spriteBatch to draw to the screen
        spriteBatch.GraphicsDevice.SetRenderTarget(null)
        //Make the screen background black
        spriteBatch.GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin();
        //Draw each target in target list to screen
        spriteBatch.End();
    }
