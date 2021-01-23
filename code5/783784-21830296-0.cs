    public static GraphicsPath CreateRoundedRectangle(Rectangle b, int r, bool fill = false)
	{
		var path = new GraphicsPath();
		var r2 = (int) r/2;
		var fix = fill ? 1 : 0;
		b.Size = new Size(b.Width - 2, b.Height - 2);
		path.AddArc(b.Left, b.Top, r, r, 180, 90);
		path.AddLine(b.Left + r2, b.Top, b.Right - r2, b.Top);
		
		path.AddArc(b.Right - r, b.Top, r, r, 270, 90);
		path.AddLine(b.Right + fix, b.Top + r2, b.Right + fix, b.Bottom - r2);
		path.AddArc(b.Right - r, b.Bottom - r, r, r, 0, 90);
		path.AddLine(b.Right - r2, b.Bottom + fix, b.Left + r2, b.Bottom + fix);
		path.AddArc(b.Left, b.Bottom - r, r, r, 90, 90);
		path.AddLine(b.Left, b.Bottom - r2, b.Left, b.Top + r2);
		return path;
	}
