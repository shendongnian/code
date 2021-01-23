    public class NotAPocoAnyMore {
      public IEnumerable<Foo> Foos { get { return foos; } }
      public IEnumerable<Bar> Bars { get { return bars; } }
    
      private List<Foo> foos;
      private List<Bar> bars;
    
      public void Add(Foo f, Bar b) {...}
      public void Remove(Foo f, Bar b) {...}
    }
