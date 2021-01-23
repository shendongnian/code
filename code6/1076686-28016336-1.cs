    // ordinal:
    Console.WriteLine("\"".StartsWith("⁍", StringComparison.Ordinal));
    Console.WriteLine("⁍".StartsWith("\"", StringComparison.Ordinal));
    Console.WriteLine("\"".Equals("⁍"));
    Console.WriteLine("⁍".Equals("\""));
    Console.WriteLine(StringComparer.Ordinal.Equals("\"", "⁍"));
    Console.WriteLine(StringComparer.Ordinal.Equals("⁍", "\""));
    Console.WriteLine(StringComparer.Ordinal.Compare("\"", "⁍"));
    Console.WriteLine(StringComparer.Ordinal.Compare("⁍", "\""));
