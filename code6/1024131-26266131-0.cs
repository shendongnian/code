    public List<string> buttonList = new List<string>() { "button1", "button2" };
    
    void SomeMethod()
    {
    	foreach (var controlName in buttonList)
    	{
    		this.Controls[controlName].Text = "TEST";	
    	}
    }
