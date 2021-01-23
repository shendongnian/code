    private static List<Tuple<string, string>> _dir = new List<Tuple<string, string>>
    {
        Tuple.Create(@"D:\", "FATAL: Disk drive doesn't exist."),
        Tuple.Create("FTP", "FATAL: Root folder doesn't exist."),
        Tuple.Create("ABC", "FATAL: Div folder doesn't exist."),
    }
    private static void SanityCheck()
    {
        var path = string.Empty;
        foreach (var t in _dir)
        {
            path = Path.Combine(path, t.Item1);
            if (!Directory.Exists(path))
            {
                Console.WriteLine(t.Item2);
                break;
            }
        }
    }
