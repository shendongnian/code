            private void resizeImage(Boolean draw, Boolean update)
        {
            if (!isValid()) return;
            if (update) 
            {
                String fileName = imageList.SelectedItem.ToString();
                var currentFile = new System.IO.FileInfo(imageList.SelectedItem.ToString());
                pictureBox1.Load(fileName);
            
            }
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bool needsCrop = true;
            if (bitmap.Width < pictureBox1.Width && bitmap.Height < pictureBox1.Height)
            {
                pictureBox1.Image = bitmap;
                needsCrop = false;
            }
            if (needsCrop)
            {
                int width, height;
                float percentWidth = (float)pictureBox1.Width / (float)bitmap.Width;
                float percentHeight = (float)pictureBox1.Height / (float)bitmap.Height;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                width = Convert.ToInt32(bitmap.Width * percent);
                height = Convert.ToInt32(bitmap.Height * percent);
                Bitmap cropBitmap = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(cropBitmap);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawImage(bitmap, 0, 0, cropBitmap.Width, cropBitmap.Height);
                pictureBox1.Image = cropBitmap;
            }
            
            if (draw) { drawRect(); }
        }
