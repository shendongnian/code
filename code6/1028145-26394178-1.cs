    public bool DoAnyValuesFail(Dictionary<string, int> dictionary, ComparisonType expression, int failureValue)
    {
        switch (expression)
        {
            case ComparisonType.Equals:
                return dictionary.Any(x => x.Value == failureValue);
            case ComparisonType.GreaterThan:
                return dictionary.Any(x => x.Value > failureValue);
            case ComparisonType.LessThan:
                return dictionary.Any(x => x.Value < failureValue);
            default:
                throw new NotSupportedException();
        }
    }
