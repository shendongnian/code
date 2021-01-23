    string filename = "<Your filename goes here>";
    var batches = Batch(File.ReadLines(filename), 20);
    foreach (var block in batches)
    {
        Console.WriteLine(block);
        Console.WriteLine("------------------------");
    }
