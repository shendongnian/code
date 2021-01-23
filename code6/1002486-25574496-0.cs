    public static IEnumerable<string> ReadLinesFromConsole()
    {
        while (true)
        {
            var next = Console.ReadLine();
            if (next == null)
                yield break;
            yield return next;
        }
    }
