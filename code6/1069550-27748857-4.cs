    public static bool Equals(LargeDecimal first, LargeDecimal second)
    {
        return ReferenceEquals(first, null) 
            ? ReferenceEquals(second, null) 
            : first.Equals(second);
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as LargeDecimal);
    }
    protected bool Equals(LargeDecimal other)
    {
        return CompareTo(other) == 0;
    }
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (wholeDigits != null)
                ? wholeDigits.GetHashCode() 
                : 0;
            hashCode = (hashCode * 397) ^ 
                (decimalDigits != null ? decimalDigits.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ IsNegative.GetHashCode();
            hashCode = (hashCode * 397) ^ IsWhole.GetHashCode();
            return hashCode;
        }
    }
