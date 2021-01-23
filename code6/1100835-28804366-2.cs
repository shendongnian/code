    public class Foo
    {
       public struct Bar myBar;      
       protected override Foo default()
       {
         return new Foo();
       }
    }
    public struct Bar
    {
       public Foo myFoo;      
    }
    var myBar = default(Bar);
