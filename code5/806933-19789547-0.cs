    public Func<User, bool> MyMethod<TProperty>(Expression<Func<User, TProperty>> func, ComparisonPredicate op, TProperty value)
    {
    }
    public enum ComparisonPredicate
    {
        Equal,
        Unequal,
        LessThan,
        LessThanOrEqualTo,
        GreaterThan,
        GreaterThanOrEqualTo
    }
