        public static Bitmap CreateNonIndexedImage(Image src) {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics gfx = Graphics.FromImage(newBmp)) {
                gfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gfx.DrawImage(src, new Rectangle(0, 0, src.Width, src.Height));
            }
            return newBmp;
        }
