    internal class Direct2DTexture2D : ITexture2D, ID2DResource
    {
        internal SharpDX.Direct2D1.Bitmap Texture2D;
        internal Direct2DTexture2D(IRenderTarget InRenderTarget, Bitmap InBitmap)
        {
            Direct2DResourceManager.OnResourceCreate(this);
            Direct2DRenderTarget RT = InRenderTarget as Direct2DRenderTarget;
            Texture2D = CreateFromBitmap(RT.RenderTarget, InBitmap);
        }
        internal Direct2DTexture2D(IRenderTarget InRenderTarget, string InFilePath)
        {
            Direct2DResourceManager.OnResourceCreate(this);
            Direct2DRenderTarget RT = InRenderTarget as Direct2DRenderTarget;
            var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(InFilePath);
            Texture2D = CreateFromBitmap(RT.RenderTarget, bitmap);
        }
        private SharpDX.Direct2D1.Bitmap CreateFromBitmap(SharpDX.Direct2D1.RenderTarget InRenderTarget, Bitmap InBitmap)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                InBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                using (SharpDX.WIC.BitmapDecoder bitDecorder =
                    new SharpDX.WIC.BitmapDecoder(Direct2DDrawingSystem.instance.ImagingFactory,
                    ms,
                    SharpDX.WIC.DecodeOptions.CacheOnDemand)
                    )
                {
                    using (SharpDX.WIC.BitmapFrameDecode bfDecode = bitDecorder.GetFrame(0))
                    {
                        using (SharpDX.WIC.FormatConverter fConverter = new SharpDX.WIC.FormatConverter(Direct2DDrawingSystem.instance.ImagingFactory))
                        {
                            fConverter.Initialize(bfDecode, SharpDX.WIC.PixelFormat.Format32bppPBGRA, SharpDX.WIC.BitmapDitherType.None, null, 0, SharpDX.WIC.BitmapPaletteType.Custom);
                            return SharpDX.Direct2D1.Bitmap.FromWicBitmap(InRenderTarget, fConverter);
                        }
                    }
                }
            }
                
        }
        public float width { get { return Texture2D.Size.Width; } }
        public float height { get { return Texture2D.Size.Height; } }
        public void Dispose()
        {
            Direct2DResourceManager.OnResourceDestroy(this);
            if (Texture2D!=null)
            {
                Texture2D.Dispose();
                Texture2D = null;
            }            
        }
    }
