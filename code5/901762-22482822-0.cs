    static void Main(string[] args)
    {
        Int64 minValue = -9223372036854775808;
        Int64 minValueViaHex = Int64.Parse("8000000000000000", NumberStyles.AllowHexSpecifier);
        Int64 minValueViaHexInline = unchecked((long)0x8000000000000000L);
        Console.WriteLine("Decimal match : {0}", Int64.MinValue == minValue);
        Console.WriteLine("Via Hex match : {0}", Int64.MinValue == minValueViaHex);
        Console.WriteLine("Via Hex inline: {0}", Int64.MinValue == minValueViaHexInline);
    }
