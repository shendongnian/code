    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var pen = new Pen(Color.Black);
        pen.Width = 16;
        pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
        var brush = Brushes.Aquamarine;
        var halfPenWidth = pen.Width/2;
        var rec = new RectangleF(Location, Size);
        rec.Width -= pen.Width;
        rec.Height -= pen.Width;
        rec.X += halfPenWidth;
        rec.Y += halfPenWidth;
        e.Graphics.FillRectangle(brush, rec);
        //Graphics.DrawRectangle does not support RectangleF directly
        e.Graphics.DrawRectangle(pen, rec.Left, rec.Top, rec.Width, rec.Height);
    }
