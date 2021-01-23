    void setBackGround(PictureBox pb, int size, Color col)
    {   
        if (size == 0 && pb.BackgroundImage != null)
        {
            pb.BackgroundImage.Dispose();
            pb.BackgroundImage = null;
            return;
        }
        Bitmap bmp = new Bitmap(size * 2, size * 2);
        using (SolidBrush brush = new SolidBrush(col))
        using (Graphics G = Graphics.FromImage(bmp) )
        {
            G.FillRectangle(brush, 0,0,size, size);
            G.FillRectangle(brush, size,size, size, size);
        }
        pb.BackgroundImage = bmp;
        pb.BackgroundImageLayout = ImageLayout.Tile;
    }
