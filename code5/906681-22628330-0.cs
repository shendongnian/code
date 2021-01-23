    for(int i = 0; i < 10; i++)
    {
        var localVar = i; // Only valid within a single iteration of the loop!
        printers.Add(delegate { Console.WriteLine(localVar); });
    }
