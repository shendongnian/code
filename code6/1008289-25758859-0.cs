    class A
    {
      public void B(){...}
      public static void B(){...}
    }
    
    ...
    
    A A = new A();
    A.B();  // <== which one is going to be called?
