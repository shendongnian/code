    ---------
    
    ****i do face the same situation and now i had to finish this with a alternate one and i will share you that.**here i have posted is for adding images in listview item for a thumbnail view.Similarly by changing the width and height of a image you can get what you wanted through return value of bitmapsource object.**
    
    **step 1**
    
    
    ----------
    
    
    import the dll file
     
    
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
         public static extern bool DeleteObject(IntPtr hObject);
    
       
    
    
    ----------
    
    
    **step 2**
       
    
     /// <summary>
        /// Gets the thumnail of the source image.
        /// </summary>
        /// <returns></returns>
    
      
    
              private BitmapSource GetThumbnail(string fileName)
                {
                    BitmapSource returnis = null;
                    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(fileName))
                    {
                        IntPtr hBitmap = GenerateThumbnail(bmp, 50);
                        try
                        {
                           returnis=System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, 
        IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                        }
                        finally
                        {
                            DeleteObject(hBitmap);
                        }
                    }
                    return returnis;
                }
    
    
    ----------
    
    
             /// <summary>
            /// GenerateThumbnail image.
            /// </summary>
            /// <param name="original">Image</param>
            /// <param name="percentage">int</param>
            /// <returns>Image</returns>
      
    
      
    
        public static IntPtr GenerateThumbnail(System.Drawing.Image original, int percentage)
            {
                try
                {
                    if (percentage < 1)
                    {
                        throw new Exception("Thumbnail size must be aat least 1% of the original size");
                    }
                    Bitmap tn = new Bitmap((int)(original.Width * 0.01f * percentage), (int)(original.Height * 0.01f * percentage));
                    Graphics g = Graphics.FromImage(tn);
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    //experiment with this...
                    g.DrawImage(original, new System.Drawing.Rectangle(0, 0, tn.Width, tn.Height), 0, 0, original.Width, original.Height,
                                GraphicsUnit.Pixel);
                    g.Dispose();
                    return tn.GetHbitmap();
                }
                catch (Exception ex)
                {
                    return IntPtr.Zero;
                }
            }
    
    
    ----------
