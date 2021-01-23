    public Form1()
    {
    	InitializeComponent();
    
    	this.BringToFront();
    	this.Focus();
    	this.KeyPreview = true;
    	this.KeyUp += new KeyEventHandler(Form1_KeyUp);
    }
        
    private void Form1_KeyUp(object sender, KeyEventArgs e)
     {
    	if (e.KeyValue == 39)
    	{
    		pad.Location = new Point(pad.Location.X + 1, pad.Location.Y);
    	}
    	else if (e.KeyValue == 37)
    	{
    		pad.Location = new Point(pad.Location.X - 1, pad.Location.Y);
    	}
    }   
