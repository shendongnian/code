    protected void Page_Load(object sender, EventArgs e)
    {
    	var radio = new RadioButton { Checked = false, AutoPostBack = true, Text = "Click" };
    	radio.CheckedChanged += radio_CheckedChanged;
    	pnl1.Controls.Add(radio);
    }
    
    void radio_CheckedChanged(object sender, EventArgs e)
    {
    	throw new NotImplementedException();
    }
