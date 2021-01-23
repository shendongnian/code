    public void Main()
    {
      try
      {
        throw new Exception("Forced Exception");
      }
      catch (Exception ex) when(MethodThatThrowsAnException())
      {
        Console.WriteLine("Filtered handler 1");
      }
      catch (Exception ex) when(MethodThatThrowsAnException2())
      {
        Console.WriteLine("Filtered handler 2");
        Console.WriteLine(ex.GetType().Name);
      }
    }
    
    private bool MethodThatThrowsAnException()
    {
      throw new NotImplementedException();   
    }
    
    private bool MethodThatThrowsAnException2()
    {
      throw new NotSupportedException();   
    }
