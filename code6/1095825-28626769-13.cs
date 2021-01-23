    public void DumpHugeString(string line, CancellationToken token)
    {
        foreach (var character in line)
        {
            token.ThrowIfCancellationRequested();
            Console.Write(character);
        }
        Console.WriteLine();
    }
