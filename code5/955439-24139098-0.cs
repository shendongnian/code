    int yLoc = 0;
    private void Button1_Click(object sender, EventArgs e)
    {
    	if (flowPanel.Location.Y <= yLoc && flowPanel.Location.Y >= flowPanel.VerticalScroll.Minimum)
    	{
			yLoc -= 50;
			flowPanel.Location = new Point(0, yLoc);
    	}
    }
    
    private void Button2_Click(object sender, EventArgs e)
    {
    	if (flowPanel.Location.Y <= yLoc && flowPanel.Location.Y < flowPanel.VerticalScroll.Maximum)
    	{
			yLoc += 50;
			flowPanel.Location = new Point(0, yLoc);
    	}
    }
