    private static void Work(CancellationToken cancelToken)
    {
       while (true)
       {
          if(cancelToken.IsCancellationRequested)
          {
            return ("999999999");
          }
         Console.Write("345");
       }
    }
