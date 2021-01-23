	private void button1_Click(object sender, EventArgs e)
	{
		button1.Visible = false;
		ThreadStart start = new ThreadStart(Animate);
		Thread thread = new Thread(start);
		thread.Start();
	}
	public void MoveButton(int x, int y)
	{
		radioButton1.Location = new Point(x, y);
	}
	public void Animate()
	{
		int BoundaryY = this.ClientSize.Height;
		while (radioButton1.Location.Y < BoundaryY)
		{
			if (radioButton1.InvokeRequired)
			{
				radioButton1.Invoke(new Action<int, int>(MoveButton), radioButton1.Location.X, radioButton1.Location.Y + 1);
			}
			Thread.Sleep(1000);
		}
	}
