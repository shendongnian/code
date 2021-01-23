    public bool IsNullOrEmpty<T>(IEnumerable<T> enumerable)
    {
        if (enumerable != null)
        {
            return enumerable.Any();
        }
        return false;
    }
