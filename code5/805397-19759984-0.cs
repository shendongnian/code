    [CategoryAttribute("Section Name"),
    DescriptionAttribute("My property description")]
    public string MyPropertyName
    {
        get { return _MyPropertyName; }
        set { _MyPropertyName = value; }
    }
    private bool ShouldSerializeMyPropertyName()
    {
    	//RETURN:
    	//		= true if the property value should be displayed in bold, or "treated as different from a default one"
    	return !(_MyPropertyName == "Default value");
    }
    private void ResetMyPropertyName()
    {
    	//This method is called after a call to 'PropertyGrid.ResetSelectedProperty()' method on this property
       _MyPropertyName = "Default value";
    }
    
    private string _MyPropertyName;
