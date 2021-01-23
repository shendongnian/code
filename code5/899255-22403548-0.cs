    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        Rectangle r = new Rectangle(0, 0, 150, 150);
        g.DrawRectangle(System.Drawing.Pens.Black, r);
    }
