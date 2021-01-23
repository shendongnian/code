    static string Rot13(string input)
    {
        if(input == null)
            return null;
        Tuple<int, int>[] ranges = { Tuple.Create(65, 90), Tuple.Create(97, 122) };
        var chars = input.Select(x =>
        {
            var range = ranges.SingleOrDefault(y => x >= y.Item1 && x <= y.Item2);
            if(range == null)
                return x;
            return ((x - range.Item1 + 13) % 26) + range.Item1;
        });
        
        return string.Concat(chars);
    }
