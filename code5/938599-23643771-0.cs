    using (Bitmap bmp = new Bitmap(cal_width, cal_height))
    {
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.DrawImage(img1,x1,y1,w1,h1);
        g.DrawImage(img2, x2, y2, w2, h2);
        g.DrawImage(img3, x3, y3, w3, h3);
        g.DrawImage(img4, x4, y4, w4, h4);
    }
    }
