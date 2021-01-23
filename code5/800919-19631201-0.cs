    public bool IsInSequence(int inputToTest, IEnumerable<int> sequence)
    {
        return sequence.Contains(inputToTest);
    }
    public bool IsInRange(int inputToTest, int start, int end)
    {
        return inputToTest>= start && inputToTest<=end ;
    }
