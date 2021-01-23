    StreamReader reader = new StreamReader(dataStream);
    while (!reader.EndOfStream)
    {
        ct.ThrowIfCancellationRequested();
        string line = await reader.ReadLineAsync());
    
        ct.ThrowIfCancellationRequested();    
        Console.WriteLine(line);
    }
