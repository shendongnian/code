    // Set the size/location of your bitmap rectangle.    
    Rectangle bmpRect = new Rectangle(0, 0, 640, 480);
        // Create a bitmap
        using (Bitmap bmp = new Bitmap(bmpRect.Width, bmpRect.Height))
        {
            // Create a graphics context to draw to your bitmap.
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                //Do some cool drawing stuff here
                gfx.DrawEllipse(Pens.Red, bmpRect);
            }
        
            //and save it!
            bmp.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MyBitmap.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        }
