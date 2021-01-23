    private static void Main(string[] args)
    {
      unsafe
      {
        string first = "hello";
    
        fixed (char* p = first)
        {
          Console.WriteLine("Address of first: {0}", ((int)p).ToString());
        }
    
        string second = "Bye";
    
        fixed (char* p = second)
        {
          Console.WriteLine("Address of second: {0}", ((int)p).ToString());
        }
    
        first = second;
    
        fixed (char* p = first)
        {
          Console.WriteLine("Address of first: {0}", ((int)p).ToString());
        }
      }
    }
