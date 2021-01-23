    public object this[string propertyName]
    {
    	get
    	{
    		Type myType = typeof(UserConfiguration);
    		PropertyInfo myPropInfo = myType.GetProperty(propertyName);
    		return myPropInfo.GetValue(this, null);
    	}
    	set
    	{
    		Type myType = typeof(UserConfiguration);
    		PropertyInfo myPropInfo = myType.GetProperty(propertyName);
    		myPropInfo.SetValue(this, value, null);
    	}
    }
