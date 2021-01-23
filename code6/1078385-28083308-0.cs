    class MyApplicationContext : ApplicationContext
    {
      public static MyApplicationContext CurrentContext;
       public MyApplicationContext(Form mainForm)
      //...implement any hooks, additional context etc.
      MainForm = mainForm;
      CurrentContext = this;
    }
