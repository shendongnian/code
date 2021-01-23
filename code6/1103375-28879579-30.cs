    public void Main()
    {
      try
      {
        throw new Exception("Forced Exception");
      }
      catch (Exception ex) when (MethodThatThrowsAnException())
      {
        Console.WriteLine("Filtered handler 1");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Filtered handler 2");
      }
    }
    
    private bool MethodThatThrowsAnException()
    {
      throw new Exception();   
    }
