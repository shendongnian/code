    Console.Write("Disk:");
    for (int j = 1; j <= 5; j++)
         Console.Write(" {0}", j);
    Console.WriteLine();
    Console.Write("Moves:");
    for (int i = 1; i <= 5; i++)                               
         Console.Write(" {2:N0}", (long)Math.Pow(n, i) - 1);
    Console.WriteLine();
