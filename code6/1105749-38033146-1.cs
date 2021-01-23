    private void Form1_Paint(object sender, PaintEventArgs e)
    {
    	e.Graphics.Clear(Color.Black);
    
    	for (int i = 0; i < values.Count; i++)
    	{
    		Brush b = new SolidBrush(Color.FromArgb(255, Rescale(values[i]), 0, 0));
    		e.Graphics.FillPie(b, 0, 0, 400, 400, (float)i, 1.0f);
    	}
    }
