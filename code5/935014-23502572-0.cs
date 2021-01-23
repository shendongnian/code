    IEnumerable<int> CharPositions(string input, char match)
    {
        int i = input.IndexOf(match, 0);
        while(i > -1)
        {
            yield return i;
            i = input.IndexOf(match, i + 1);
        }
    }
