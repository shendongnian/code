          //  Create Temp Bitmap Image 
           Bitmap    bmpImgDisp =
                    new Bitmap(250, 250);  // your size of rect.
          using (Graphics g = Graphics.FromImage(bmpImgDisp))
                {
                       g.DrawImage(YourMainpictuerBox.Image, new RectangleF(0, 0, 250, 250), rect size you want to clip {x,y,height,widht}, GraphicsUnit.Pixel);
                }
