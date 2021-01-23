    public static void Main()
    {
      ConsoleKeyInfo cki;
      if (ConsoleEx.TryReadKey(TimeSpan.FromSeconds(5), out cki))
      {
        Console.WriteLine("ReadKey returned a value.");
      }
      else
      {
        Console.WriteLine("ReadKey timed out.
      }
    }
