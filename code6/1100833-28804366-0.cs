    public abstract class Foo
    {
       protected Foo(int bar)
       {
       }      
       protected override Foo default()
       {
         return new Foo(50); // You can't instantiate an abstract class
       }
    }
    //..
    Foo myFoo = default(Foo);
    
