    class MyApplicationContext : ApplicationContext
    {
      public static MyApplicationContext CurrentContext;
      
       public MyApplicationContext(Form mainForm) : base(mainForm)
       {
         //...implement any hooks, additional context etc.
      
         CurrentContext = this;
       }
    }
