    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        EffectTechnique effectTechnique = _basicEffect.Techniques[0];
        EffectPassCollection effectPassCollection = effectTechnique.Passes;
        foreach (EffectPass pass in effectPassCollection)
        {
            pass.Apply();
            GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, _vertexPositionColors, 0, 4);
        }
        base.Draw(gameTime);
    }
