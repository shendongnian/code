    if (!control.Context.IsCurrent)
    {
        control.MakeCurrent();
    }
    GL.Ortho(0, controlWidth, 0, controlHeight, -1000, 1000);
    GL.Scale(1, -1, 1); // I work with a top/left image and openGL is bottom/left
    GL.Viewport(0, 0, controlWidth, controlHeight);
    GL.ClearColor(Color.White);
    GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
    GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
    GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);
    GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
    GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
    GL.Enable(EnableCap.PointSmooth);
    GL.Enable(EnableCap.LineSmooth);
    GL.Enable(EnableCap.Blend);
    GL.Enable(EnableCap.DepthTest);
    GL.ShadeModel(ShadingModel.Smooth);
    GL.Enable(EnableCap.AutoNormal);
    bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    gfx = Graphics.FromImage(bmp);
    gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    texture = GL.GenTexture();
    GL.BindTexture(TextureTarget.Texture2D, texture);
    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
    GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0,
    OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
