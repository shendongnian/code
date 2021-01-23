    public void CreateEllipse(int a, int b, int h, int k, float theta)
    {
        VertexPositionColor[] vertices = new VertexPositionColor[vertexCount];
        //Drawing an Ellipse with its major axis parallel to the x-axis. Rotation can be applied to change this.
        Vector3 position;
        const float max = MathHelper.Pi;
        //2 * max since we're moving from -Pi to +Pi in the loop.
        float step = 2 * max / (float)vertexCount;
        int i = 0;
        //Optional Axis and angle rotation for the ellipse (See later notes):
        //Vector3 axis = new Vector3(0, 0, -1);
        float angle = MathHelper.ToRadians(theta);
    
        for (float t = -max; t <= max; t += step)
        {
            //Formula shamelessly taken from wikipedia
            position = new Vector3(h + a * (float)Math.Cos((double)t), k + b * (float)Math.Sin((double)t), 0f);
            //Optional Rotation for the Ellipse:
            //position = Vector3.Transform(position, Matrix.CreateFromAxisAngle(axis, angle));
            vertices[i] = new VertexPositionColor(position, Color.DarkOrange);
            i++;
        }
        //Optional Rotation for the Ellipse:
        position = Vector3.Transform(position, Matrix.CreateFromAxisAngle(axis, angle));
        //then add the first vector again so it's a complete loop (sounds familiar)
        position = new Vector3(h + a * (float)Math.Cos((double)-max), k + b * (float)Math.Sin((double)-max), 0f);
        vertices[vertexCount - 1] = new VertexPositionColor(position, Color.DarkOrange);
    
        vertexBuffer = new VertexBuffer(device, vertexCount * VertexPositionColor.SizeInBytes,
            BufferUsage.WriteOnly);
        vertexBuffer.SetData<VertexPositionColor>(vertices);
    }
