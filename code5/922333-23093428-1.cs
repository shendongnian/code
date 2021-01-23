    public enum ComparisionType
    {
        Equal,
        Less,
        Greater,
        LessOrEqual,
        GreaterOrEqual
    }
    public static bool Compare<T>(T a, ComparisionType compType, T b)
        where T : IComparable<T>
    {
        switch (compType)
        {
            case ComparisionType.Equal:
                return a.CompareTo(b) == 0;
            case ComparisionType.Less:
                return a.CompareTo(b) < 0;
            case ComparisionType.Greater:
                return a.CompareTo(b) > 0;
            case ComparisionType.LessOrEqual:
                return a.CompareTo(b) <= 0;
            case ComparisionType.GreaterOrEqual:
                return a.CompareTo(b) >= 0;
        }
        throw new ApplicationException();
    }
