    public override void Draw(Graphics g)
    {
    	Pen pen = new Pen(Color);
    	GraphicsPath gp = new GraphicsPath();
    	StringFormat format = StringFormat.GenericDefault;
    	gp.AddString(_theText, _font.FontFamily, (int)_font.Style, _font.SizeInPoints,
    					new PointF(Rectangle.X, Rectangle.Y), format);
    	// Rotate the path about it's center if necessary
    	if (Rotation != 0)
    	{
    		RectangleF pathBounds = gp.GetBounds();
    		Matrix m = new Matrix();
    		m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)),
    					MatrixOrder.Append);
    		gp.Transform(m);
    	}
    	g.DrawPath(pen, gp);
    	rectangle.Size = g.MeasureString(_theText, _font).ToSize();
    	pen.Dispose();
    }
