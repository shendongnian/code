    public static string Between(this string input, char delimiter)
    {
        return string.Join(" ", input.Split(delimiter).Where((x, i) => i % 2 != 0));
    }
    var result = input.Between('"');
