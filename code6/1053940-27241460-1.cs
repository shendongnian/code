    foreach (string f in Directory.GetFiles(sDir, "*.log", SearchOption.AllDirectories))
    {
        foreach (string line in Tail(f, 2, Encoding.Default)
            .Where(line => line.IndexOf("error", StringComparison.OrdinalIgnoreCase) > 0)))
        {
            WriteError(line);
        }
    }
