    if (File.Exists("list.txt"))
    {
        string[] files = File.ReadAllLines("list.txt");
        foreach(string fileName in files)
            if (File.Exists(fileName))
            {
                Console.WriteLine(fileName);
            }
            else
            {
                throw new FileNotFoundException(fileName);
            }
    }
    else
    {
        Console.WriteLine("Cannot find som' files");
    }
    Console.ReadKey(true);
