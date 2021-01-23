    public enum ComparisonType
    {
        Equal,
        Less,
        Greater,
        LessOrEqual,
        GreaterOrEqual
    }
    public static bool Compare<T>(T a, ComparisonType compType, T b)
        where T : IComparable<T>
    {
        switch (compType)
        {
            case ComparisonType.Equal:
                return a.CompareTo(b) == 0;
            case ComparisonType.Less:
                return a.CompareTo(b) < 0;
            case ComparisonType.Greater:
                return a.CompareTo(b) > 0;
            case ComparisonType.LessOrEqual:
                return a.CompareTo(b) <= 0;
            case ComparisonType.GreaterOrEqual:
                return a.CompareTo(b) >= 0;
        }
        throw new ApplicationException();
    }
