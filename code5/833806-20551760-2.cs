    foreach (var t in ingredients.ZipToTuple(newAmounts, units))
    {
        writer.Write(t.Item1 + ",");
        writer.Write(t.Item2 + ",");
        writer.Write(t.Item3 + "\n");
    }
