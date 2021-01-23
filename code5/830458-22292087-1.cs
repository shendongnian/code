    public static void Draw(Texture texture, List<RenderTarget2D> targetList)
    {
        RenderTarget2D target = new RenderTarget2D(...);
        //Tell spriteBatch to draw to target instead of the screen
        spriteBatch.GraphicsDevice.SetRenderTarget(target);
        //Make the renderTarget's background clear
        spriteBatch.GraphicsDevice.Clear(new Color(0,0,0,0)) 
        spriteBatch.Begin();
        //Apply effect and draw
        spriteBatch.End();
        targetList.Add(target);
    }
