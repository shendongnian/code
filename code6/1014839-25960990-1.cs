    public static IEnumerable<string> Permutate(string[] words)
    {
        int[] indices = new int[words.Length]; // 0 0 0
        while (CountStep(indicies)) // moves to 0 0 1 and so on, returns false after 3 3 3
        {
            yield return string.Join("-", indicies.Select(x => words[x]));
        }
    }
