    var tuples = ingredients
        .Zip(newAmounts,
            (i, a) => new Tuple<string, string>(i, a))
        .Zip(units,
            (t, a) => new Tuple<string, string, string>(t.Item1, t.Item2));
    
    foreach (var t in tuples)
    {
        writer.Write(t.Item1 + ",");
        writer.Write(t.Item2 + ",");
        writer.Write(t.Item3 + "\n");
    }
