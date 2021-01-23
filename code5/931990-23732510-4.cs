    class SomeClass
    {
       public someMethod3()
       {
          using(Context context = new Context()) //now wrapping the context in a using to ensure it is disposed
          {
             context.doSomething;
          }
       }
    }
