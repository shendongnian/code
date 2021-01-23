    void drawIntoImage()
    {
        using (Graphics G = Graphics.FromImage(pictureBox2.Image))
        {
            G.DrawEllipse(Pens.Orange, new Rectangle(13, 14, 44, 44));
        }
    }
