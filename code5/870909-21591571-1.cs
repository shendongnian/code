	private bool retracted = false;
	private void pic1_MouseEnter(object sender, EventArgs e)
	{
		if (retracted)
		{
			pic1.Location = new Point(328, 316);
		}
		else
		{
			pic1.Location = new Point(328, 300);
		}
		retracted = !retracted;
	}
