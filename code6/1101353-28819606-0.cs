    private static void Main(string[] args)
    {
        var a = Combinations("100");
        var b = Combinations("10000");
    }
    public static IEnumerable<string> Combinations(string input)
    {
        var combinations = new List<string>();
        combinations.Add(input);
        for (int i = 0; i < input.Length; i++)
        {
            char[] buffer= input.ToArray();
            if (buffer[i] == '0')
            {
                buffer[i] = 'o';
                combinations.Add(new string(buffer));
                combinations = combinations.Concat(Combinations(new string(buffer))).ToList();
            }
        }
        return combinations.Distinct();
    }
