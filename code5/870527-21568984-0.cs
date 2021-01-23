    graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
    graphics.ApplyChanges();
    AlphaTestEffect alphaTestEffect = new AlphaTestEffect(pGraphicsDevice);
    alphaTestEffect.VertexColorEnabled = true;
    alphaTestEffect.DiffuseColor = Color.White.ToVector3();
    alphaTestEffect.AlphaFunction = CompareFunction.Equal;
    alphaTestEffect.ReferenceAlpha = 0;
    alphaTestEffect.World = Matrix.Identity;
    alphaTestEffect.View = Matrix.Identity;
    Matrix projection = Matrix.CreateOrthographicOffCenter(0, 400,400, 0, 0, 1);
    alphaTestEffect.Projection = projection;
            // Create fog of war mask
            if (mFogOfWarRT == null)
            {
                mFogOfWarRT = new RenderTarget2D(pGraphics.GraphicsDevice, MapSize, MapSize, false, SurfaceFormat.Color, DepthFormat.Depth24Stencil8);
                pGraphics.GraphicsDevice.SetRenderTarget(mFogOfWarRT);
                
            }
            else
            {
                pGraphics.GraphicsDevice.SetRenderTarget(mFogOfWarRT);
            }
            //important both stencil states be created in their own object, cannot modify once set for some reason.
            DepthStencilState lState = new DepthStencilState();
            lState.StencilEnable = true;
            lState.StencilFunction = CompareFunction.Always;
            lState.ReferenceStencil = 1;
            lState.StencilPass = StencilOperation.Replace;
            lState.DepthBufferEnable = false;
            pGraphicsDevice.Clear(ClearOptions.Target | ClearOptions.Stencil,
                                      new Color(0, 0, 0, 1), 0, 0);
            pSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, lState, null, alphaTestEffect);
            foreach (ClearArea lArea in mDrawQueue)
            {
    //draw whatever you want "visible" anything in the texture with an alpha of 0 will be allowed to draw.
                pSpriteBatch.Draw(mAlphaMask, new Rectangle((int)lArea.X, lArea.Y, lArea.Diameter, lArea.Diameter), Color.White);
            }
 
            pSpriteBatch.End();
 
            // Draw minimap texture
            DepthStencilState lState2 = new DepthStencilState();
            lState2.StencilEnable = true;
            lState2.StencilFunction = CompareFunction.Equal;
            lState2.ReferenceStencil = 0;
            lState2.StencilPass = StencilOperation.Keep;
            lState2.DepthBufferEnable = false;
            pSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, lState2, null);
            pSpriteBatch.Draw(mDot, new Rectangle(0, 0, 400, 400), Color.Black);
 
            pSpriteBatch.End();
            //done drawing to the render target
            pGraphicsDevice.SetRenderTarget(null);
            pGraphicsDevice.Clear(Color.Gray);
            pSpriteBatch.Begin();
            pSpriteBatch.Draw(mDot, new Rectangle(0, 0, 400, 400), Color.Blue);
            pSpriteBatch.Draw(mFogOfWarRT,Vector2.Zero,Color.White);
            pSpriteBatch.End();
