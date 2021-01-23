    RasterizerState r = new RasterizerState();
    r.ScissorTestEnable  = true;
    spriteBatch.GraphicsDevice.RasterizerState = r;
    ....
    RasterizerState r1 = new RasterizerState();
    r1.ScissorTestEnable = false;
    spriteBatch.GraphicsDevice.RasterizerState = r1;
