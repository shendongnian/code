    foreach (var line in File.ReadLines("Name.txt"))
    {
        Console.WriteLine(line);
    }
    Console.WriteLine("Please enter a name to add to the list.");
    var name = Console.ReadLine();
    File.AppendLine("Name.txt", name):
