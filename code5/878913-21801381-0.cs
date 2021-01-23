    public string PhoneNumber{get;set;}
    public string Prefix
    {
     get
     {
           return PhoneNumber.substring(0, 3);
      }
      set
      {
       _prefix = value;
      }
     }
    public string Postfix
    {
      get
      {
        return PhoneNumber.substring(3);
      }
      set
      { 
        _postfic = value;
       }
     }
