    // chars is a test IObservable<char> 
    string[] messages = { "A1234", "B12345", "C123456" };
    var serialPort = Enumerable.Range(1, 10).ToObservable();
    var chars = serialPort.SelectMany((_, i) => messages[i % 3]);
    
    var packets = chars.Scan(
        Tuple.Create(string.Empty, -1),
        (acc, c) =>
            Char.IsLetter(c)
                ? Tuple.Create(c.ToString(), GetPacketLength(c) - 1)
                : Tuple.Create(acc.Item1 + c, acc.Item2 - 1))
        .Where(acc => acc.Item2 == 0)
        .Select(acc => acc.Item1)
        .Subscribe(Console.WriteLine);
