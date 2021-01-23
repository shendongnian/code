    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace YourNamespace
    {
        public static class TheClassinWhichYouWantToPlaceTheFunction
        {
            public static Bitmap RotateImageN(Bitmap b, float angle)
            {
                //Create a new empty bitmap to hold rotated image.
                Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
                //Make a graphics object from the empty bitmap.
                Graphics g = Graphics.FromImage(returnBitmap);
                //move rotation point to center of image.
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //Rotate.        
                g.RotateTransform(angle);
                //Move image back.
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //Draw passed in image onto graphics object.
                //Found ERROR 1: Many people do g.DwarImage(b,0,0); The problem is that you re giving just the position
                //Found ERROR 2: Many people do g.DrawImage(b, new Point(0,0)); The size still not present hehe :3
    
                g.DrawImage(b, 0,0,b.Width, b.Height);  //My Final Solution :3
                return returnBitmap;
            }
       }
    }
