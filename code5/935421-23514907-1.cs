    public class Form2 : System.Windows.Forms.Form
    {
    	public Form2()
    	{
    		InitializeComponent();
    	}
    	
    	TextBox _txtboxToSetReadOnly = null;
    	public TextBox txtboxToSetReadOnly
    	{
    		set{ this._txtboxToSetReadOnly = value; }
    		get {return this._txtboxToSetReadOnly;}
    	}
    
    	private void checkbox1_Click(object sender, EventArgs e)
            {
    		if( this._txtboxToSetReadOnly != null)	this._txtboxToSetReadOnly.ReadOnly = checkbox1.Checked;
    		/*
    		 or the otherway 
    		if( this._txtboxToSetReadOnly != null) this._txtboxToSetReadOnly.ReadOnly = !checkbox1.Checked;
    		*/
    	}
    }
