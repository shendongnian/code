    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media.Imaging;
    using Point = System.Drawing.Point;
    public static class ImageHelper
    {
        #region Enums
        public enum ImageType
        {
            Bitmap = 0, 
            PNG = 1
        }
        #endregion
        #region Public Methods and Operators
        public static Bitmap BitmapSourceToBitmap(BitmapSource bitmapsource, ImageType type = ImageType.Bitmap)
        {
            Bitmap bitmap;
            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = null;
                if (type == ImageType.Bitmap)
                {
                    enc = new BmpBitmapEncoder();
                }
                else
                {
                    enc = new PngBitmapEncoder();
                }
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
  
            }
            return bitmap;
        }
        public static Image BitmapSourceToImage(BitmapSource image)
        {
            var ms = new MemoryStream();
            var encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(ms);
            ms.Flush();
            return Image.FromStream(ms);
        }
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(
                source.GetHbitmap(), 
                IntPtr.Zero, 
                Int32Rect.Empty, 
                BitmapSizeOptions.FromEmptyOptions());
        }
        public static Bitmap SetBitmapResolution(Bitmap bitmap, float dpiX, float dpiY)
        {
            bitmap.SetResolution(dpiX, dpiY);
            return bitmap;
        }
        public static Bitmap Superimpose(Bitmap largeBmp, Bitmap smallBmp)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            g.CompositingMode = CompositingMode.SourceOver;
            // smallBmp.MakeTransparent();
            int margin = 2;
            int x = largeBmp.Width - smallBmp.Width - margin;
            int y = largeBmp.Height - smallBmp.Height - margin;
            g.DrawImage(smallBmp, new Point(x, y));
            return largeBmp;
        }
        #endregion
    }
