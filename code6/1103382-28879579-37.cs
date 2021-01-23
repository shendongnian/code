    public void Main()
    {
      try
      {
        try
        {
          throw new Exception("Forced Exception");
        }
        catch (Exception ex) when (MethodThatThrowsAnException())
        {
          Console.WriteLine("Filtered handler 1");
        }
      }
      catch (Exception ex)
      {
          Console.WriteLine("Caught");
          Console.WriteLine(ex);
      }
    }
    
    private bool MethodThatThrowsAnException()
    {
      throw new Exception("MethodThatThrowsAnException");   
    }
