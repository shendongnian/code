    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.DrawEllipse(new Pen(Color.Red, 20), new Rectangle(50, 100, 50, 100));
    }
