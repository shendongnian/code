    public int MethodToTest(Collection<int> collection)
    {
        var sum = 0;
        if (collection != null)
        {
            foreach (var value in collection)
            {
                sum += value;
            }
        }
        return sum;
    }
