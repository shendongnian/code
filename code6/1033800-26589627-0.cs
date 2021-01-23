    var list = new List<string[]>
    {
        new [] {"tom", "abc", "$525.34", "$123"},
        new [] {"dick", "xyz", "$100", "$234"},
        new [] {"harry", "", "$250.01", "$40"},
        new [] {"bob", "", "$250.01", ""}
    };
    var cutlure = new CultureInfo("en-US");
    var result = list.Aggregate((decimal[])null, (sums, strings) =>
        {
            if (sums == null)
                sums = Enumerable.Repeat(decimal.MinValue, strings.Length).ToArray();
            for (int i = 0; i < strings.Length; i++)
            {
                decimal value;
                if (decimal.TryParse(strings[i], NumberStyles.Currency, cutlure, out value))
                    sums[i] = (sums[i] == decimal.MinValue) ? value : sums[i] + value;
            }
            return sums;
        },
        sums => sums.Select(sum => (sum == decimal.MinValue) ? "N/A" : sum.ToString()).ToArray());
