        public void drawText(string text, Font drawFont)
        {
            Bitmap bmp = new Bitmap(canvasWidth, canvasHeight);
            Graphics G = Graphics.FromImage(bmp);
            SolidBrush brush = new SolidBrush(paintColor);
            Point point = new Point( yourOriginX, yourOriginY );
            G.DrawString(text, drawFont, brush, point);
            for (int x = 0; x < canvasWidth; x++)
                for (int y = 0; y < canvasHeight; y++)
                {
                    Color pix = bmp.GetPixel(x, y);
                        setCell(x, y, pix);     //< -- set your custom pixels here!
                }
            bmp.Dispose();
            brush.Dispose();
            G.Dispose();
        }
