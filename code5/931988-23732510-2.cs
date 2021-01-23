    class SomeClass
    {
       private context = new Context(); //sharing your context with all methods
       public someMethod()
       {
          context.doSomething;
       }
    
       public someMethod2()
       {
          context.doSomething;
       }
    }
