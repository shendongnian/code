    protected override void LoadContent()
    {
        _vertexPositionColors = new[]
        {
            new VertexPositionColor(new Vector3(0, 0, 1), Color.Red),
            new VertexPositionColor(new Vector3(10, 0, 1), Color.Red),
            new VertexPositionColor(new Vector3(10, 10, 1), Color.Red),
            new VertexPositionColor(new Vector3(0, 10, 1), Color.Red)
        };
        _basicEffect = new BasicEffect(GraphicsDevice);
        _basicEffect.World = Matrix.CreateOrthographicOffCenter(
            0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 0, 0, 1);
    }
