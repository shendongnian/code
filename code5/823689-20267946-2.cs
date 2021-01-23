    var cons = GetTwoConnections();
    using (cons.Item1, cons.Item2)
    {
        // use first connection as cons.Item1 and second one as cons.Item2
    }
