    public static IEnumerable<string> Permutate(string[] words)
    {
        // 0 0 0
        int[] indices = new int[words.Length];
        // yield 0 0 0
        yield return string.Join("-", indicies.Select(x => words[x]));
        // moves to 0 0 1 and so on, returns false after 3 3 3
        while (CountStep(indicies))
        {
            // yield next permutation
            yield return string.Join("-", indicies.Select(x => words[x]));
        }
    }
