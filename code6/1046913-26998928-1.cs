    // This will remove all the stocks you want.
    ticker.RemoveAll(s => s.TickerSymbol == "gm");
    foreach (Stock s in ticker)
    {
        Console.WriteLine(s.Name);
    }
