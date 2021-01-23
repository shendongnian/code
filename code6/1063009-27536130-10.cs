    Bitmap hoverImage(Image img, Size size, Padding pad)
    {
        Bitmap bmp = new Bitmap(size.Width, size.Height);
        // client rectangle
        Rectangle cRect = new Rectangle(pad.Left, pad.Top, 
             size.Width - pad.Left - pad.Right, size.Height - pad.Top - pad.Bottom);
        // image proportion
        float fi = 1f * img.Width / img.Height;
        // target size
        int nw = fi >= 1 ? cRect.Width : (int)(1f * cRect.Width / fi);
        int nh = (int)(1f * nw / fi);
        if (nh > cRect.Height)
        {
            nh = cRect.Height;
            nw = (int)(1f * nh * fi);
        }
        Size nSize = new Size(nw, nh);
        Point dPoint = new Point(pad.Left + (cRect.Width - nw) / 2, 
                                 pad.Top + (cRect.Height - nh) / 2);
        using ( Graphics G = Graphics.FromImage(bmp) )
        {
            Rectangle dRect = new Rectangle(dPoint, nSize);
            Rectangle sRect = new Rectangle(Point.Empty, img.Size);
            Rectangle shRect = new Rectangle(dRect.X - 3, dRect.Y - 3, 
                                             dRect.Width + 8, dRect.Height + 8);
            for (int i = 0; i < 6; i++)
            {
                using (Pen pen = new Pen(Color.FromArgb(i * 15, Color.Black))) 
                        G.DrawRectangle(pen, shRect);
                shRect.Inflate(-1, -1);
            }
            G.DrawImage(img, dRect, sRect, GraphicsUnit.Pixel);
        }
        return bmp;
    }
