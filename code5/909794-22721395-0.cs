    private static void ProcessInput(string[] words, int minLength, int maxLength)
    {
        var groups = from word in words
                     where word.Length > 0 && word.Length >= minLength && word.Length <= maxLength
                     let key = new Tuple<char, char>(word.First(), word.Last())
                     group word by key into @group
                     orderby Char.ToLowerInvariant(@group.Key.Item1), @group.Key.Item1, Char.ToLowerInvariant(@group.Key.Item2), @group.Key.Item2
                     select @group;
        Console.WriteLine("Length: {0}-{1}", minLength, maxLength);
        foreach (var group in groups)
        {
            Console.WriteLine("First letter: {0}, Last letter: {1}", group.Key.Item1, group.Key.Item2);
            foreach (var word in group)
                Console.WriteLine("\t{0}", word);
        }
    }
