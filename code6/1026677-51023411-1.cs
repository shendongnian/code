     internal class Direct2DTexture2D : ITexture2D, ID2DResource
    {
        private System.IO.MemoryStream MemStream;
        private SharpDX.WIC.BitmapDecoder BitDecorder;
        private SharpDX.WIC.BitmapFrameDecode BFDecorde;
        private SharpDX.WIC.FormatConverter fConverter;
        internal SharpDX.Direct2D1.Bitmap Texture2D;
        internal Direct2DTexture2D(IRenderTarget InRenderTarget, Bitmap InBitmap)
        {
            Direct2DResourceManager.OnResourceCreate(this);
            Direct2DRenderTarget RT = InRenderTarget as Direct2DRenderTarget;
            CreateFromBitmap(RT.RenderTarget, InBitmap);
        }
        internal Direct2DTexture2D(IRenderTarget InRenderTarget, string InFilePath)
        {
            Direct2DResourceManager.OnResourceCreate(this);
            Direct2DRenderTarget RT = InRenderTarget as Direct2DRenderTarget;
            var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(InFilePath);
            CreateFromBitmap(RT.RenderTarget, bitmap);
        }
        private void CreateFromBitmap(SharpDX.Direct2D1.RenderTarget InRenderTarget, Bitmap InBitmap)
        {
            MemStream = new System.IO.MemoryStream();
            InBitmap.Save(MemStream, System.Drawing.Imaging.ImageFormat.Png);
            BitDecorder = new SharpDX.WIC.BitmapDecoder(Direct2DDrawingSystem.instance.ImagingFactory,
                                MemStream,
                                SharpDX.WIC.DecodeOptions.CacheOnDemand);
            BFDecorde = BitDecorder.GetFrame(0);
            fConverter = new SharpDX.WIC.FormatConverter(Direct2DDrawingSystem.instance.ImagingFactory);
            fConverter.Initialize(BFDecorde, SharpDX.WIC.PixelFormat.Format32bppPBGRA, SharpDX.WIC.BitmapDitherType.None, null, 0, SharpDX.WIC.BitmapPaletteType.Custom);
            Texture2D = SharpDX.Direct2D1.Bitmap.FromWicBitmap(InRenderTarget, fConverter);
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
            if(fConverter!=null)
            {
                fConverter.Dispose();
                fConverter = null;
            }
            if(BFDecorde != null)
            {
                BFDecorde.Dispose();
                BFDecorde = null;
            }
            if(BitDecorder!=null)
            {
                BitDecorder.Dispose();
                BitDecorder = null;
            }
            if(MemStream!=null)
            {
                MemStream.Dispose();
                MemStream = null;
            }
        }
    }
