    public void Main()
    {
      try
      {
        try
        {
          throw new NotSupportedException("Forced Exception");
        }
        catch (Exception ex) when (MethodThatThrowsAnException())
        {
          Console.WriteLine("Filtered handler 1");
        }
      }
      catch (Exception ex)
      {
          Console.WriteLine(ex.GetType().Name);
          Console.WriteLine("Caught");
      }
    }
    
    private bool MethodThatThrowsAnException()
    {
      throw new NotImplementedException();   
    }
