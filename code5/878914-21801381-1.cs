    public string PhoneNumber{get;set;}
    public string Prefix
    {
     get
     {
           return PhoneNumber.substring(0, 3);
      }
      set
      {
       // replace the first three chars of PhoneNumber
       PhoneNumber = value + PhoneNumber.Substring(3);
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
        // replace the  chars of starting from index 3 of PhoneNumber
          PhoneNumber =  PhoneNumber.Substring(0, 3)+value;
       }
     }
