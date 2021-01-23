        public void drawText(string text)
        {
            Bitmap bmp = new Bitmap(canvasWidth, canvasHeight);
            Graphics G = Graphics.FromImage(bmp);
            SolidBrush brush = new SolidBrush(paintColor);
            Point point = new Point(clickedCell.ColumnIndex - canvasX - 2,clickedCell.RowIndex - canvasY - 3 );
            G.DrawString(text, drawFont, brush, point);
            for (int x = 0; x < canvasWidth; x++)
                for (int y = 0; y < canvasHeight; y++)
                {
                    Color pix = bmp.GetPixel(x, y);
                        setCell();     //< -- set your custom pexels here!
                }
            bmp.Dispose();
            brush.Dispose();
        }
