    public class A
    {
      public String Foo;
    }
    public class B : A
    {
      SetFoo(String foo)
      {
        Foo = foo
      }
    }
    public class C : A
    {
      UseFoo()
      {
        PrintLn(Foo);
      }
    }
