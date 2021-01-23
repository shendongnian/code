                [System.Runtime.InteropServices.DllImport("gdi32.dll")]
                public static extern bool DeleteObject(IntPtr hObject);
                IntPtr bmp;
    {
                    if (bmp != null)
                    {
                        DeleteObject(bmp);
                    }
                    Bitmap bmap = new Bitmap(640, 480, System.Drawing.Imaging.PixelFormat
                                                             .Format24bppRgb);
                    bmp = bmap.GetHbitmap();
                    BitmapSource bmapSource = System.Windows.Interop.Imaging.
                      CreateBitmapSourceFromHBitmap(bmp, IntPtr.Zero, Int32Rect.Empty,
                                                    BitmapSizeOptions.FromEmptyOptions());
                    bmap.Dispose();
                    bmap = null;
                    
                    image.Source = bmapSource;
    }
