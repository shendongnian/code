    try
    {
         Console.WriteLine("BET OR PASS? (BET == 0 / PASS == 1)");
         int n = int.Parse(Console.ReadLine());
         if (n != 0 || n != 1)
             throw new InvalidArgumentException();
         return n;
    }
