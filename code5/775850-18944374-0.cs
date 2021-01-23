    internal interface ITest
    {
      void Foo();
      void Bar();
    }
    public class Thing : ITest
    {
      void ITest.Foo() { this.Foo(); }
      void ITest.Bar() { this.Bar(); }
      public Foo() { ... }
      internal Bar() { ... }
    }
