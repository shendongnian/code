    foreach (string path in paths)
    {
        foreach (string line in File.ReadLines(path))
        {
            if (line.Contains(Name))
            {
                Console.WriteLine("found");
                break;
            }
        }
    }
