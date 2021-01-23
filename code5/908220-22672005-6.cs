    public static IEnumerable<string> GetLogicalNames<T, TResult>(
        Expression<Func<T, TResult>> lambda)
    {
        return from member in ParameterAccesses(lambda)
                let attributes = member.GetCustomAttributes<AttributeLogicalNameAttribute>()
                where attributes.Any()
                select attributes.First().LogicalName;
    }
