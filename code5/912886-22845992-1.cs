    foreach (string file in Directory.EnumerateFiles(path, "*.xml"))
    {
        try { XElement.Load(file); }
        catch
        {
            string name = Path.GetFileName(file);
            Console.WriteLine(name + " is missing a root element");
        }
    }
