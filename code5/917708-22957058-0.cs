            Rectangle rectToExclude = new Rectangle(200, 30, 250, 30);//rectangle to be excluded
            Bitmap myBitmap = new Bitmap(pictureBox1.Image);
            for (x = 0; x < pictureBox1.Image.Width; x += 1)
            {
                for (y = 0; y < pictureBox1.Image.Height; y += 1)
                {
                    if (rectToExclude.Contains(x, y)) continue; // if in the exclude rect then contines without any doing effects
                    Color pixelColor = myBitmap.GetPixel(x, y);
                    aws = pixelColor.GetBrightness();
                }
            }
