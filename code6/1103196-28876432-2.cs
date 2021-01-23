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
          switch(columnName)
          {
              case "SomeName":
              {
                   if (string.IsNullOrEmpty(this.Status))
                   {
                      return "Please bla bla..";
                   }
                   break;
              }
              case "SomeOtherName":
              {
                   if (string.IsNullOrEmpty(this.OtherProperty))
                   {
                      return "Please bla bla..";
                   }
                   break;
              }
              
          }
          return string.Empty;         
          
       }
    }
    
    public string Error
    {
       get
       {
          return this["SomeName"]+this["SomeOtherName"];
       }
    }
    #endregion
