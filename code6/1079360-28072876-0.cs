    public string GetStringValue(string valToGet)
    {
        string rv = (string)this.GetPropertyValue(this, valToGet);        
        //or
        //string rv = (string)UserData.GetPropertyValue(this, valToGet);        
        return rv;
    }
