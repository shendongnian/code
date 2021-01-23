    public void RemoveUnwantedLines(string filename, Predicate<string> unwanted)
    {
        var lines = File.ReadAllLines(filename);
        File.WriteAllLines(filename, lines.Where(line => !unwanted(line)));
    }
