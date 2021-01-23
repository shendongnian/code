    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    [ProgId("mythumbnailer.provider"), Guid("insert-your-guid-here")]
    public class QBThumbnailProvider : IThumbnailProvider, IInitializeWithStream
    {
        #region IInitializeWithStream
        private StreamWrapper stream{ get; set; }
        public void Initialize(IStream stream, int grfMode)
        {
            // IStream passed to our wrapper which handles our clean up
            this.stream = new StreamWrapper(stream);
        }
        #endregion
        #region IThumbnailProvider
        public void GetThumbnail(int cx, out IntPtr hBitmap, out WTS_ALPHATYPE bitmapType)
        {
            hBitmap = IntPtr.Zero;
            bitmapType = WTS_ALPHATYPE.WTSAT_ARGB;
            try
            {
                //... bunch of other code
                // set the hBitmap somehow
                using (MemoryStream stream = new MemoryStream(buffer))
                using (var image = new Bitmap(stream))
                using (var scaled = new Bitmap(image, cx, cx))
                {
                    hBitmap = scaled.GetHbitmap();
                    
                    // for x64 versions of windows
                    hBitmap = (IntPtr)(hBitmap.ToInt64());
                }
            }
            catch (Exception ex)
            {
            }
            // release the IStream COM object
            stream.Dispose();
        }
        #endregion
    }
