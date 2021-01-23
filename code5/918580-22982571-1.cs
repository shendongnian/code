    void Main()
    {
        try
        {
            Execute();
        }
        catch(Exception x)
        {
            Console.WriteLine("In main: " + x.Message);
        }
        
    }
    
    public void Execute()
    {
      // Goes to the catch block in main
      //throw new Exception("bada boom");
      try
      {
          // Goes to the catch block associated with this try
          throw new Exception("bada bing");
      }
      catch(Exception x)
      {
          // Uncomment this to see the null reference exception in main
          // Console.WriteLine("In Execute: " + x.InnerException.Message);
          Console.WriteLine("In Execute:" + x.Message);
      }
    }
