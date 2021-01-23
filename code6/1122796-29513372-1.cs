    private Pen _pen = new Pen(Color.Black, 2);
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        var rec = new Rectangle(2, 2, 820, 620);
        if (e.ClipRectangle.IntersectsWith(rec))
            e.Graphics.DrawRectangle(_pen, rec);
        var rec2 = GetRect2();
        if (e.ClipRectangle.IntersectsWith(rec2))
            e.Graphics.DrawRectangle(pi, rec2);
     }
