    class Full {
      public string ValueA {get;set;}
    }
    
    class Limited : Full {
      public new string ValueA {get; private set;}
    }
