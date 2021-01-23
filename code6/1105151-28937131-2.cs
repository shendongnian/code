    public static IEnumerable<char> GetVowels(this string value)
    {
        var vowels = new[]{'a', 'e', 'i', 'o', 'u'};
        return value.ToCharArray()
            .Join(vowels,
                c => Char.ToUpper(c),
                v => Char.ToUpper(v),
                (_, v) => v);
    }
