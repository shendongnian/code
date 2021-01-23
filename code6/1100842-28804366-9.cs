    public abstract class Foo
    {
       protected Foo(int x)
       {
       }      
       protected override Foo default()
       {
         return new Foo(50); // You can't instantiate an abstract class
       }
    }
    //..
    Foo myFoo = default(Foo);
    
