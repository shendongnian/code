    class Operation
    {
      public void Execute()
      { 
        try { ... }
        catch (Exception ex)
        {
        Console.Writeline($"{nameof(Operation)}.{nameof(Execute)} has encountered exception:{Environment.NewLine}{Environment.NewLine}{ex.Message}" );
        }
       }
    }
