    // culture-sensitive:
    Console.WriteLine("\"".StartsWith("⁍"));
    Console.WriteLine("⁍".StartsWith("\""));
    Console.WriteLine("\"".StartsWith("⁍", StringComparison.InvariantCulture));
    Console.WriteLine("⁍".StartsWith("\"", StringComparison.InvariantCulture));
    Console.WriteLine("\"".Equals("⁍", StringComparison.CurrentCulture));
    Console.WriteLine("⁍".Equals("\"", StringComparison.CurrentCulture));
    Console.WriteLine("\"".Equals("⁍", StringComparison.InvariantCulture));
    Console.WriteLine("⁍".Equals("\"", StringComparison.InvariantCulture));
            
    Console.WriteLine(StringComparer.CurrentCulture.Equals("\"", "⁍"));
    Console.WriteLine(StringComparer.CurrentCulture.Equals("⁍", "\""));
    Console.WriteLine(StringComparer.InvariantCulture.Equals("\"", "⁍"));
    Console.WriteLine(StringComparer.InvariantCulture.Equals("⁍", "\""));
            
    Console.WriteLine("\"".CompareTo("⁍"));
    Console.WriteLine("⁍".CompareTo("\""));
            
    Console.WriteLine(StringComparer.CurrentCulture.Compare("\"", "⁍"));
    Console.WriteLine(StringComparer.CurrentCulture.Compare("⁍", "\""));
    Console.WriteLine(StringComparer.InvariantCulture.Compare("\"", "⁍"));
    Console.WriteLine(StringComparer.InvariantCulture.Compare("⁍", "\""));
