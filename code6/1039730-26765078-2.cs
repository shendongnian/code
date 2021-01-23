    public class B()
    {
      A MyA;
     
      public B()
      { 
        MyA = new A();
        MyA.Message += MessageHandler;
      }
     
      public string MessageHandler(string s)
      {
        // Do other code here and ensure you're returning a string as defined in your Message event.
        return s;
      }
    }
