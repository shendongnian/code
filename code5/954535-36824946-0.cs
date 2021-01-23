      public static SharpDX.Direct2D1.Bitmap GetBitmapFromSRV(SharpDX.Direct3D11.ShaderResourceView srv, RenderTarget renderTarger)
        {
            using (var texture = srv.ResourceAs<Texture2D>())
            using (var surface = texture.QueryInterface<Surface>())
            {
                var bitmap = new SharpDX.Direct2D1.Bitmap(renderTarger, surface, new SharpDX.Direct2D1.BitmapProperties(new SharpDX.Direct2D1.PixelFormat(
                                                          Format.R8G8B8A8_UNorm,
                                                          SharpDX.Direct2D1.AlphaMode.Premultiplied)));
                return bitmap;
            }
        }
