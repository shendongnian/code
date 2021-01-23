    public bool IsButtonEnabled
    {       
      get
      {
        return !String.IsNullorEmpty(String1) && !String.IsNullorEmpty(String2);
      }
    
    }
