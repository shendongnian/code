	public void DrawImageRotated(Graphics g, Image Image, Point Location, double Angle)
	{
		g.ResetTransform();
		g.RotateTransform(Angle);
		g.TranslateTransform(Location.X, Location.Y, Drawing2D.MatrixOrder.Append);
		g.DrawImageUnscaled(Image, -Image.Width / 2, -Image.Height / 2);
		g.ResetTransform();
	}
