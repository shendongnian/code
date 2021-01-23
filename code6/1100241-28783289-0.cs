    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle rect = new Rectangle(25, 25, 25, 25);
        e.Graphics.TranslateTransform(25, 25);
        e.Graphics.DrawRectangle(Pens.Black, rect);
        for (int i = 0; i < 15; i++)
        {
            rect.Inflate(3,3);
            e.Graphics.TranslateTransform(5, 2);
            e.Graphics.RotateTransform(2f);
            e.Graphics.DrawRectangle(Pens.Black, rect);
        }
    }
