    private void Form1_Load(object sender, EventArgs e)
    {
        int tileWidth = 30;
        int tileHeight = 30;
        int tileRows = 30;
        int tileCols = 30;
        using (Bitmap sourceBmp = new Bitmap("D:\\900x900.jpg"))
        {
            Size s = new Size(tileWidth, tileHeight);
            Rectangle destRect = new Rectangle(Point.Empty, s);
            for (int row = 0; row < tileRows; row++)
                for (int col = 0; col < tileCols; col++)
                {
                    PictureBox p = new PictureBox();
                    p.Size = s;
                    Point loc = new Point(tileWidth * col, tileHeight * row);
                    Rectangle srcRect = new Rectangle(loc, s);
                    Bitmap tile = new Bitmap(tileWidth, tileHeight);
                    Graphics G = Graphics.FromImage(tile);
                    G.DrawImage(sourceBmp, destRect, srcRect, GraphicsUnit.Pixel);
                    p.Image = tile;
                    p.Location = loc;
                    p.Tag = loc;
                    p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                    this.Controls.Add(p);
                }
        }
    }
