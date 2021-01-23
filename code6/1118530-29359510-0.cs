    private bool ContainsInSequence(string input, string substring)
    {
        int substringIndex = 0;
        for (int i = 0; i < input.Count(); i++)
        {
            if (input[i] == substring[substringIndex])
            {
                substringIndex++;
                if (substringIndex == substring.Length)
                {
                    return true;
                }
            }
        }
        return false;
    }
