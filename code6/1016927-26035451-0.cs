    a.Symbol = new StringBuilder("a");
    b.Symbol = a.Symbol;
    a.Symbol.Clear();
    a.Symbol.Append("b");
    b.Symbol.Dump();
