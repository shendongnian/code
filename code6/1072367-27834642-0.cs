    public IEnumerable<string> GetEnumValues(string enumName)
    {
        foreach (var value in Enum.GetValues(Type.GetType(enumName)))
        {
            yield return value.ToString();
        }
    }
