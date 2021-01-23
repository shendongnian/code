    if (!control.Context.IsCurrent)
    {
        control.MakeCurrent();
    }
    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
    GL.MatrixMode(MatrixMode.Modelview);
    GL.Enable(EnableCap.Texture2D);
    GL.BindTexture(TextureTarget.Texture2D, Texture);
    GL.Begin(PrimitiveType.Quads);
    GL.TexCoord3(0.0f, 0.0f, 0f); GL.Vertex3(0f, 0f, 0f);
    GL.TexCoord3(1.0f, 0.0f, 0f); GL.Vertex3(realWidth, 0f, 0f);
    GL.TexCoord3(1.0f, 1.0f, 0f); GL.Vertex3(realWidth, realHeight, 0f);
    GL.TexCoord3(0.0f, 1.0f, 0f); GL.Vertex3(0f, realHeight, 0f);
    GL.End();
    GL.Disable(EnableCap.Texture2D);
    control.SwapBuffers();
