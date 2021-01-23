    Bitmap bmp = new Bitmap(300, 300);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Point);
                g.Clear(Color.White);
                g.DrawString("Hello", font, Brushes.Black, 0, 0);
            }
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
            Bitmap newBitmap = new Bitmap(300, 300, bmpData.Stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, bmpData.Scan0);
            newBitmap.Save(@"c:\x\x.bmp");
