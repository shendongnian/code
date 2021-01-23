       private Bitmap overlayBitmap(Bitmap sourceBMP, int width, int height) {
            Bitmap result = new Bitmap(width + (width/3), height + (height/3));
            using (Graphics g = Graphics.FromImage(result)) {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(sourceBMP, width / 6, height / 6, width, height);
            }
            return result;
        }
