    public static void FitControlFont(Control control)
	{
		if (control.Text.Length == 0)
		{
			return;
		}
		Graphics graphics = control.CreateGraphics();
		Font newFont = (Font)control.Font.Clone();
		bool sizeFound = false; // to test if we already found the right size
		bool initiallyToSmall = false; // is the initial text to small (we will increase the font size) or too big (decrease the font size)
		float step = 1F; // increase/decrease step
		SizeF newSize = graphics.MeasureString(control.Text, newFont, new SizeF(control.Width, control.Height));
		if (newSize.Width <= control.Width && newSize.Height <= control.Height)
			initiallyToSmall = true;
		do
		{
			newSize = graphics.MeasureString(control.Text, newFont, new SizeF(control.Width, control.Height * 2));
			if (initiallyToSmall)
			{
				if (newSize.Height > control.Height)
				{
					newFont = new Font(control.Font.Name, newFont.SizeInPoints - step); // get previous size
					sizeFound = true;
				}
				else
					newFont = new Font(control.Font.Name, newFont.SizeInPoints + step);
			}
			else
			{
				if (newSize.Width <= control.Width && newSize.Height <= control.Height)
					sizeFound = true;
				else
					newFont = new Font(control.Font.Name, newFont.SizeInPoints - step);
			}
				
		} while (!sizeFound && newFont.SizeInPoints > 1 && newFont.SizeInPoints < 100);
		graphics.Dispose();
		if (control.InvokeRequired)
		{
			control.Invoke(new MethodInvoker(delegate { control.Font = newFont; }));
		}
		else
		{
			control.Font = newFont;
		}
	}
