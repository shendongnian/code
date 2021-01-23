    public class Derived {  //TODO: Rename to `NotSoDerived` 
      public Derived(Base b, Something<Other> something) { ... }
      public ItHappenedEventHandler<Other> itHappened ...;
      public void SomeBaseMethod() {
        b.SomeBaseMethod(); // let b handle this call
      }
    }
