    interface Callable
    {
      void Called();
    }
    class Test
    {
      public Test(Callable x)
      {
        this.callable = callable;
      }
      public void Start()
      {
        if (true)
          callable.Called();
      }
 
      private Callable callable;
    }
