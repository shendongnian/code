    var symbols = "£$€#&%+-";
    var punctuationsChars =  Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue)
                                .Select(i => (char)i)
                                .Where(c => char.IsPunctuation(c))
                                .Except(symbols)
                                .ToArray();
    string input = "leave £10 remove £ and leave 10% remove % ok";
    var parts = input.Split(punctuationsChars)
                     .SelectMany(x => x.Split())
                     .Where(x => !(x.Length == 1 && symbols.Contains(x[0])))
                     .ToList();
