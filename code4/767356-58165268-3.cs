    if (await TryParseIntAsync("-13", out var result))
    {
        Console.WriteLine($"Result: {await result}");
    }
    else
    {
        Console.WriteLine($"Parse failed");
    }
