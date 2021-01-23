    public MyDialog (Gtk.Window parent) 
             : base ("My title", parent, Gtk.DialogFlags.Modal, new object[0])
    {
    	this.Build();
    }
    public override void Dispose ()
	{
		Destroy();
		base.Dispose();
	}
