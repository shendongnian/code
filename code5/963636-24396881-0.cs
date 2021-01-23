    // chars is a test IObservable<char> 
    string[] messages = { "A1234", "B12345", "C123456" };
    var serialPort = Enumerable.Range(1, 10).ToObservable();
    var chars = serialPort.SelectMany((_, i) => messages[i % 3]);
    
    var packets = chars
        .Scan(Tuple.Create(0, '\0'),
            (accumulator, c) =>
                char.IsLetter(c)
                    ? Tuple.Create(accumulator.Item1 + 1, c)
                    : Tuple.Create(accumulator.Item1, c))
        .GroupBy(i => i.Item1)
        .SelectMany(g => g.Select(c => c.Item2).ToArray())
        .Select(cArr => new String(cArr))
        .Subscribe(acc => Console.WriteLine(acc));
