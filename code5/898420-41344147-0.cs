    private static void Example(string value, Type type, ParameterExpression pe, string propertyName)
    {
        Expression whereValue = null;
        if (type.IsEnumOrNullableEnum())
        {
            whereValue = Expression.Constant(Enum.Parse(type, value));
        }
        Expression propExp = Expression.Property(pe, propertyName);
        Expression ruleExpression = Expression.Equal(propExp, whereValue);//results in: item.MyEnum = A
    }
