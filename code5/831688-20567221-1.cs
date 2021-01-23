    class SomeClass
    {
      public string foo{ get;set;}
      private BarItems bars {get;set;}     
      
      public IEnumerable<Bar> Bars
      {
        get
        {
          return bars.bar ?? new IEnumerable<Bar>();
        }
        set
        {
          bars.bar = value;
        }
      }
    }
    class BarItems
    {
         public IEnumerable<Bar> bar {get;set;}
    }
