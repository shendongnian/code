    public class Base<T, TFiled>
    {
          public void ValidateInsert(TFiled filed)
          {
        
          }
    }
    
     public class Derived : Base<Derived, long>
        {
            public long Id { get; set; }
        }
    
        public class AnotherDerived : Base<Derived, string>
        {
            public string IdSring { get; set; }
        }
    
    
      public class MyObject
        {
            private Derived d = new Derived();
    
            private AnotherDerived anotherIsntance = new AnotherDerived();
    
            public MyObject()
            {
                d.ValidateInsert(10);
                anotherIsntance.ValidateInsert("some string");
            }
    
        }
