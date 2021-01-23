    public class Base {
      public Base(DatabaseStuff d, TimerStuff t) { ... }
    }
    public class Derived : Base {
      public Derived(DatabaseStuff d, TimerStuff t, Something<Other> something) : base(d,t) {...}
    }
