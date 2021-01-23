	private void panel1_MouseMove(object sender, MouseEventArgs e)
	{
		if (flag)
		{
			g = panel1.CreateGraphics();
			myPen.Width = 3;
			Point p2 = new Point();
			p2 = e.Location;
			g.DrawLine(myPen, p, p2);
			p = p2; // just add this
		}
	}
