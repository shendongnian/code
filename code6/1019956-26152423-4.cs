    public int MethodToTest(Collection<int> collection)
    {
        var sum = 0;
        foreach (var value in collection)
        {
            sum += value;
        }
        return sum;
    }
