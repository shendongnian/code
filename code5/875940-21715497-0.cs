        public static Image ResizeImage(Image img, Size size) {
            var bmp = new Bitmap(size.Width, size.Height);
            using (var gr = Graphics.FromImage(bmp)) {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gr.DrawImage(img, new Rectangle(Point.Empty, size));
            }
            return bmp;
        }
