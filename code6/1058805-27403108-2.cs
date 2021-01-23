    // Split each input string into a letters and numbers part.
    public static IEnumerable<Tuple<string, int>> Split(this IEnumerable<string> input)
    {
        foreach (var item in input)
        {
            var letters = string.Concat(item.TakeWhile(c => !char.IsDigit(c)));
            var digits = string.Concat(item.SkipWhile(c => !char.IsDigit(c)));
            yield return new Tuple<string, int>(letters, Int32.Parse(digits));
        }
    }
