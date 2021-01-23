    protected void OnExposeEvent(object o, ExposeEventArgs e)
    {
    	Gdk.Window window = e.Event.Window;      
    	using (System.Drawing.Graphics graphics =
    		Gtk.DotNet.Graphics.FromDrawable(window))
    	{
    		// draw your stuff here...
    		graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black), 0, 0, 30, 40);
    	}
    }
