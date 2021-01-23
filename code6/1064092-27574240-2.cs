    MemberExpression[] memberExpressions = 
    {
        Expression.Property(param, "BoolA"),
        Expression.Property(param, "BoolB"),
        Expression.Property(param, "BoolC"),
        Expression.Property(param, "BoolD"),
    };
    MultiCounter multiCounter = new MultiCounter(memberExpressions.Length, 3);
    List<Expression> expList = new List<Expression>(memberExpressions.Length);
    do
    {
        expList.Clear();
        for (int index = 0; index < memberExpressions.Length; index++)
        {
            int propertyCounter = multiCounter[index];
            if (propertyCounter == 2)
            {
                continue;
            }
            expList.Add(Expression.Equal(
                memberExpressions[index],
                Expression.Constant(propertyCounter == 1)));
        }
        // Process expList here
    } while (multiCounter.Increment());
