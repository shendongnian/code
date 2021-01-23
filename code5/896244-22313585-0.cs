    public abstract class Base<TDerived> where TDerived : Base {
      public abstract TDerived Clone();
    }
    
    public class Derived1 : Base<Derived1> {
      public override Derived1 Clone() { ... }
    }
    
    public class Derived2 : Base<Derived2> {
      public override Derived2 Clone() { ... }
    }
