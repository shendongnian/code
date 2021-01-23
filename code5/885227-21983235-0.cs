    public string Name 
    {
        get { return this.GetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name).ToString(); }
        set { this.SetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name, value); }
    }
    
    public int Age
    {
        get { return int.Parse(this.GetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name).ToString()); }
        set { this.SetPropertyValue(System.Reflection.MethodBase.GetCurrentMethod().Name, value); }
    }
