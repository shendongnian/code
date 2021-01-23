    // declaration
    [Flags] 
    enum ScreenColors 
    {
        None = 0,
        Red = 1,
        Yellow = 2,
        Blue = 4 
    }
     
    private void button1_Click(object sender, EventArgs e)
    {
    	ScreenColors selectedColors = ScreenColors.None;
    
    	if (red1.Checked || red2.Checked)
    	{
    		selectedColors |= ScreenColors.Red;
    	}    	
    	// etc for yellow, blue
    
    	// now I have a flags enum with only the 2 colours I care about
    
    	// so I can build a lookup table that says what combinations of source colors maps to what destination
    
    	Dictionary<ScreenColors, Color> lookups = new Dictionary<ScreenColors, Color>()
    	{
    		{ScreenColors.Red, Color.Red},
    		{ScreenColors.Yellow, Color.Yellow},
    		{ScreenColors.Blue, Color.Blue},
    		{ScreenColors.Red | ScreenColors.Blue, Color.Purple},
    		{ScreenColors.Red | ScreenColors.Yellow, Color.Orange},
    		{ScreenColors.Blue | ScreenColors.Yellow, Color.Green},
    	};
    
    	//... and now all I have to do is look up the flags in the dictionary to get the correct background
    	this.BackColor = lookups[selectedColors];
    }
