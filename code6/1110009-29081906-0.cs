    var file = @"C:\temp\names.txt";
    
    Console.WriteLine("Opening file {0}", file);
    foreach(var name in File.ReadLines(file))
    {
        Console.WriteLine("Printing letters in name: {0}", name);
        foreach(var letter in name)
        {
            Console.WriteLine(letter);
        }
    }
    Console.WriteLine("Done reading file");
