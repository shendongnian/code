    public static bool DescriptionEquals(this Enum value, string inputForComparison,
        StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase)
    {
        string description;
        try
        {
            description = value.GetDescription();
        }
        catch (Exception ex) when (ex is AmbiguousMatchException || ex is TypeLoadException)
        {
            return false;
        }
        if (description == null || inputForComparison == null)
        {
            return false;
        }
        return inputForComparison.Equals(description, comparisonType);
        //  || inputForComparison.Equals(value.ToString(), comparisonType); may be added
    }
