            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            var Bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics gfx = Graphics.FromImage(Bmp))
            using (var brush = new SolidBrush(Color.BlueViolet))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }
            pictureBox1.Image = Bmp;
