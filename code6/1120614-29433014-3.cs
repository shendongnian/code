    public string Format(string format, double value)
    {
        var regex = new Regex(@"^(?<IntPart>.*)([.,]0*)$");
        var s = String.Format("{0:F4}", value);
        var match = regex.Match(s);
        if (match.Success)
        {
            return match.Groups["IntPart"].Value;
        }
        return s;
    }
    Console.WriteLine(Format("{0:F4}", 1.35687));    // 1.3569
    Console.WriteLine(Format("{0:F4}", 1.35));       // 1.3500
    Console.WriteLine(Format("{0:F4}", 1));          // 1
    Console.WriteLine(Format("{0:F4}", 42.000001));  // 42
