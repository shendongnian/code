    public string Name
    {
        get { return this.GetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name).ToString(); }
        set { this.SetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name, value); }
    }
    
    public int Age
    {
        get { return (int)this.GetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name); }
        set { this.SetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name, value); }
    }
    
    
    public object GetPropertyValue(string sPropertyName)
    {
    
        sPropertyName = sPropertyName.ToLower();
    
        if (mdPropertyBag.ContainsKey(sPropertyName.Replace("get_", "")))
        {
            return mdPropertyBag[sPropertyName.Replace("get_", "")];
    
        }
        else
        {
    
            return null;
        }
    }
