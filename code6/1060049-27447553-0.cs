    public BitmapSource SaveToImage(bool automaticOrientation = false)
            {
                // Set OpenGL context
                // -------------------------------------------------------------------------------  
                this.MakeCurrent();
                // Render the scene offscreen and get framebuffer bytes
                // -------------------------------------------------------------------------------                
                byte[] bmpBuffer = this.renderer.GetOffscreenBytes(automaticOrientation);
                // Convert the bytes to a Bitmap source
                // ------------------------------------------------------------------------------- 
                BitmapSource srcBMP = CreateBitmap(GLCore.HWSETTINGS.OFFBUFF_SIZE, GLCore.HWSETTINGS.OFFBUFF_SIZE, bmpBuffer, System.Windows.Media.PixelFormats.Bgr24);
                bmpBuffer           = null;
                return srcBMP;
            }
    public static BitmapSource CreateBitmap(int width, int height, byte[] bmpBuffer, System.Windows.Media.PixelFormat pixelFormat)
            {
                var bitmap = new WriteableBitmap(width, height, 96, 96, pixelFormat, null);
                bitmap.WritePixels(new Int32Rect(0, 0, width, height), bmpBuffer, bitmap.BackBufferStride, 0);
                bitmap.Freeze();
                return bitmap;
            }
