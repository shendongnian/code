    public string RemoveZeroes(string input, int count)
    {
        if (count < 1 || !input.StartsWith("0"))
            return input;
        return RemoveZeroes(input.Remove(0, 1), count - 1);
    }
