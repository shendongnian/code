    private void Form1_LocationChanged(object sender, EventArgs e)
	{
		try
		{
			popup.Location = new Point(popup.Location.X + this.Left - lastPos.X,
				popup.Location.Y + this.Top - lastPos.Y);
			if (popup.Location.X < 0)
				popup.Location = new Point(0, popup.Location.Y);
		}
		catch (NullReferenceException)
		{
		}
		lastPos = this.Location;
	}
