    public class A : B
    {
       public A()
       {
          //you can now call the methods defined in B
          base.SomeMethod();
       }
    }
