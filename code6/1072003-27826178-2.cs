    public IEnumerable<DataRange> ParseInput(string input)
    {
        if (!Regex.IsMatch(input.Replace(Environment.NewLine, string.Empty).Dump(), @"^[\d\.,\- ]+$"))
            return Enumerable.Empty<object>();
            
        return input
            .Replace(" ", string.Empty)
            .Split(new[] { Environment.NewLine, "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => Regex.Match(x, @"(?<A>\d+(\.\d+)?)(-(?<B>\d+(\.\d+)?))?"))
            .Select(m => new DataRange
            {
                A = double.Parse(m.Groups["A"].Value, System.Globalization.CultureInfo.InvariantCulture),
                B = m.Groups["B"].Success ? double.Parse(m.Groups["B"].Value, System.Globalization.CultureInfo.InvariantCulture) : (double?)null
            });
    }
    
    public class DataRange
    {
        public double A;
        public double? B;
    }
