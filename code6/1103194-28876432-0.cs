    public bool SomethingIsValid
    {
       get
       {
          return string.IsNullOrEmpty(Error);
       }
    }
    
    public string this[string columnName]
    {
       get
       {
          if ("SomeName" == columnName)
          {
             if (string.IsNullOrEmpty(this.Status))
             {
                return "Please bla bla..";
             }
          }
          
          return string.Empty;
       }
    }
    
    public string Error
    {
       get
       {
          return this["SomeName"];
       }
    }
    #endregion
