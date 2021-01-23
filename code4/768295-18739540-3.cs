    static string Rot13(string input)
    {
        var lowerCase = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
        var upperCase = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
        var mapItems = new[]
        {
            lowerCase.Zip(lowerCase.Skip(13).Concat(lowerCase.Take(13)), (k, v) => Tuple.Create(k, v)),
            upperCase.Zip(upperCase.Skip(13).Concat(upperCase.Take(13)), (k, v) => Tuple.Create(k, v))
        };
        var map = mapItems.SelectMany(x => x).ToDictionary(x => x.Item1, x => x.Item2);
                           
        return new string(input.Select(x => Map(map, x)).ToArray());
    }
    
    static char Map(Dictionary<char, char> map, char c)
    {
        char result;
        if(!map.TryGetValue(c, out result))
            return c;
        return result;
    }
