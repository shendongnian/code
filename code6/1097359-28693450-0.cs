    public void Draw(params)
    {
        RenderTarget2D renderTarget = new RenderTarget2D(GraphicsDevice, 1920, 1080); // Might want some parameters, dunno
        GraphicsDevice.SetRenderTarget(renderTarget);
        // Render stuff as usual
        GraphicsDevice.SetRenderTarget(null); // Resets it
        spritebatch.Begin();
        spritebatch.Draw(renderTarget.GetTexture(), new Rectangle(0, 0, WindowWidth, WindowHeight), params...);
        spritebatch.End();
    }
