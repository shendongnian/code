    var punctuationsChars =  Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue)
                                .Select(i => (char)i)
                                .Where(c => char.IsPunctuation(c))
                                .Except("£$€#&+-")
                                .ToArray();
    string input = ..............
    var parts = input.Split(punctuationsChars).SelectMany(x => x.Split()).ToList();
