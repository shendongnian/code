    void drawIntoImage()
    {
        using (Graphics G = Graphics.FromImage(pictureBox1.Image))
        {
            G.DrawEllipse(Pens.Orange, new Rectangle(13, 14, 44, 44));
            ..
        }
        // when done with all drawing you can enforce the display update by calling:
        pictureBox1.Refresh();
    }
