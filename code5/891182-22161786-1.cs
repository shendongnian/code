	private bool expanding;
	private bool selectActive = false;
	private Point selectStart;
	private Point selectPosition;
	private bool selecting;
	private bool selectionExists;
	private bool manualFinding;
 
 
	private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
	{
		if (!selectActive)
		{
			return;
		}
		if (e.Button == System.Windows.Forms.MouseButtons.Left)
		{
			selectStart = e.Location;
			selecting = true;
		}
	}
	private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
	{
		if (selecting)
		{
			selectPosition = e.Location;
			pictureBox1.Invalidate();
		}
	}
	private void pictureBox1_Paint(object sender, PaintEventArgs e)
	{
		int x = Math.Min(selectStart.X, selectPosition.X);
		int y = Math.Min(selectStart.Y, selectPosition.Y);
		int w = Math.Abs(selectStart.X - selectPosition.X);
		int h = Math.Abs(selectStart.Y - selectPosition.Y);
		if (selectionExists || selecting)
		{
			e.Graphics.DrawRectangle(Pens.Red, x, y, w, h);
		}
	}
	private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
	{
		if (!selecting)
		{
			return;
		}
		if (e.Button == System.Windows.Forms.MouseButtons.Left)
		{
			selecting = false;
			selectionExists = true;
		}
	}
