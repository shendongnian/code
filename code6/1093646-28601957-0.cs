    while ((line = reader.ReadLine()) != null)
    {
        line.ToList().ForEach(c => { Console.Write(c); Console.Write(" "); });
        Console.WriteLine();
        line.ToList().ForEach(c => { Console.Write(Convert.ToInt32(c)); Console.Write(" "); });
        Console.WriteLine();
        EBCDIC.GetBytes(line).ToList().ForEach(c => { Console.Write(c); Console.Write(" "); });
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
