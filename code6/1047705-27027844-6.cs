    public class PropertyClass
    {
    	public PropertyClass()
    	{
    		Value = "default";
    	}
    
    	public PropertyClass(string value)
    	{
    		Value = value;
    	}
    
    	public string Value { get; private set; }
    }
    
    public class WhateverClass
    {
    	public PropertyClass Property { get; set; }   
    }
