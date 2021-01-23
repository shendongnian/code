    public string A{get;set;} //Auto property
    public string A
    {
      get{return a;}`
      set{
    //Do some check-Processing
        if(value != null)
           a=value;
        }
    }
