    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Media.Imaging;
    
    namespace XYZ.Helpers
    {
        public class ConvertBitmapToBitmapImage
        {
            /// <summary>
            /// Takes a bitmap and converts it to an image that can be handled by WPF ImageBrush
            /// </summary>
            /// <param name="src">A bitmap image</param>
            /// <returns>The image as a BitmapImage for WPF</returns>
            public BitmapImage Convert(Bitmap src)
            {
                MemoryStream ms = new MemoryStream();
                ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
