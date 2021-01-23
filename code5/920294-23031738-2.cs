    public static bool CommandExists(String value)
    {
        string[] commands = File.ReadAllText("commands.txt")
                       .Split()
                       .Where(x => x.StartsWith("!"))
                       .Distinct()
                       .ToArray();
        return commands.Contains(value);
    }
