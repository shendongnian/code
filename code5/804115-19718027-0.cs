    public partial class MyDialog : Gtk.Dialog
    {
    
    	public string Results {
    		get;
    		private set;
    	}
    
    	public MyDialog ()
    	{
    		this.Build ();
    	}
    
    	protected override bool OnDeleteEvent (Gdk.Event evnt)
    	{
    		Results = entry2.Text; // if user pressed on X button..
    		return base.OnDeleteEvent (evnt);
    	}
    
    	protected void OnButtonOkClicked (object sender, EventArgs e)
    	{
    		Results = entry2.Text;
    		Destroy ();
    	}
    
    	protected void OnButtonCancelClicked (object sender, EventArgs e)
    	{
    		Results = string.Empty;
    		Destroy ();
    	}
    }
