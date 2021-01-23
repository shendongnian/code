    foreach (string file in Directory.EnumerateFiles(@"C:\Path\", "*.xml"))
    {
        try { XElement.Load(file); }
        catch
        {
            string name = Path.GetFileName(file);
            Console.WriteLine(name + " is missing a root element");
        }
    }
