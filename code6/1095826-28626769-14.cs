    public void DumpHugeString(string line, CancellationToken token)
    {
        foreach (var characterBatch in line.Batch(100))
        {
            token.ThrowIfCancellationRequested();
            Console.Write(characterBatch.ToArray());
        }
        Console.WriteLine();
    }
