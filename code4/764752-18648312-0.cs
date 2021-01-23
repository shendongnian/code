    public T Filter<T>(string target, string actual, T value, T defaultValue = default(T))
    {
        bool isMatch = !string.IsNullOrEmpty(target)
            && !string.IsNullOrEmpty(actual)
            && string.Equals(target, actual, StringComparison.CurrentCultureIgnoreCase)
        return isMatch ? value : defaultValue;
    }
