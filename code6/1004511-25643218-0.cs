    public abstract class Parent()
    {
      public Parent() { }
      public void CommonMethod() { /* do something */ }
      abstract public PropertyA {get; set;}
      abstract public PropertyB {get; set;}
    }
    public class Child : Parent
    {
       override public string PropertyA { get; set; }
       override public string PropertyA { get; set; }
       public Child() : base()
}
