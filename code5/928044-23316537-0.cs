    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    
    namespace Example
    {
        public class ImageData
        {
            public static byte[] BytesFromImage(Image image)
            {
    			//Parse the image to a bitmap
                Bitmap bmp = new Bitmap(image);
                
    			// Set the area we're interested in and retrieve the bitmap data
    			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);            
                
    			// Create a byte array from the bitmap data
    			int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
                byte[] rgbValues = new byte[bytes];
                IntPtr ptr = bmpData.Scan0;
    			Marshal.Copy(ptr, rgbValues, 0, bytes);
                
    			bmp.UnlockBits(bmpData);
                
    			//return the byte array
    			return rgbValues;
            }
        }
    }
