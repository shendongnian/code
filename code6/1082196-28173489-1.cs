    public static void Main()
    {
        var characters = new[]
                         {
                             new[] { 'a', 'b' },
                             new[] { 'a', 'b' },
                             new[] { '1', '2' }
                         };
        var combinations = GenerateCombinations(characters);
        foreach (var combination in combinations)
        {
            Console.WriteLine(combination);
        }
    }
