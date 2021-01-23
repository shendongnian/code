    private static string CreateRange(string num)
    {
        var tokens = num.Split('-').Select(s => s.Trim()).ToArray();
        // use UInt64 to allow huge numbers
        var start = UInt64.Parse(tokens[0]);
        var end = UInt64.Parse(tokens[1]);
        // if your start number is '000123', this will create
        // a format string with 6 zeros ('000000')
        var format = new string('0', tokens[0].Length);
        // use StringBuilder to make GC happy.
        // (if only there was a Enumerable.Range<ulong> overload...)
        var sb = new StringBuilder();
        for (var i = start; i <= end; i++)
        {
            // format ensures that your numbers are padded properly
            sb.Append(i.ToString(format));
            sb.Append(", ");
        }
        // trim trailing comma after the last element
        if (sb.Length >= 2) sb.Length -= 2;
            
        return sb.ToString();
    }
