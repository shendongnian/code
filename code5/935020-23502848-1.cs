    public static IEnumerable<int> CharPositions(string input, char match)
    {
        for (int i = 0; i < input.Length; i++)
        {
           if (input[i] == match)
                 yield return i;
        }
    }
