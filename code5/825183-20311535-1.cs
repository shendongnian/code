    void stripSeparator_Paint(object sender, PaintEventArgs e)
    {
    	ToolStripSeparator stripSeparator = sender as ToolStripSeparator;
    	ContextMenuStrip menuStrip = stripSeparator.Owner as ContextMenuStrip;
    	e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, stripSeparator.Width, stripSeparator.Height));
    	using (Pen pen = new Pen(Color.LightGray, 1))
    	{
    		e.Graphics.DrawLine(pen, new Point(0, stripSeparator.Height / 2), new Point(menuStrip.Width, stripSeparator.Height / 2));
    	}
    }
