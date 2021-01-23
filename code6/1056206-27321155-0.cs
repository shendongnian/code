    public static string[] GetPropertyNames(params Expression<Func<DTO, object>>[] pExpressions)
    {
        List<string> propertyNames = new List<string>();
        foreach (Expression<Func<DTO, object>> expression in pExpressions)
        {
            propertyNames.Add(GetPropertyName(expression));
        }
        return propertyNames.ToArray();
    }
