    [ComVisibleAttribute(true)] //required
    class MyJsInterface
    {
      public string Test()
      {
        return "Hello World!";
      }
    }
    browser1.ObjectForScripting = new MyJsInterface(); //for example
