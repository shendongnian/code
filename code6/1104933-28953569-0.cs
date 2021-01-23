    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
    Rectangle source = (Rectangle)_ground.UserData;
    source.Y -= _groundTexture.Height % source.Height;
    Rectangle destination = new Rectangle(0, graphics.GraphicsDevice.Viewport.Height - ((Rectangle)_ground.UserData).Height, source.Width, source.Height);
    spriteBatch.Draw(_groundTexture, destination, source, Color.White);
    spriteBatch.End();
