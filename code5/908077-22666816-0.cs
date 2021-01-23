    string[] files = Directory.GetFiles(@"SomeWhere");
    List<string> result = new List<string>();
    foreach (string file in files)
    {
        string[] lines = File.ReadAllLines(file);
        // Grab information from the lines and store it in result
        // by using result.Add(...) or result.AddRange(...)
    }
    File.WriteAllLines(@"AlsoSomewhere", result);
