     public class MyClass
     {
         Foo m_foo = null; // member, the "= null" part is redundant and not needed
         Foo m_foo = new Foo(); // member, initialized as part of the constructor call
         void Bar()
         {
              Foo f; // Local variable
              f.MyMethod(); // Compile time error: f is not initialized
              Foo f2=null;
              f2.MyMethod(); // Runtime error: Nullreference exception
         }
     }
