    /// <summary>
    /// Gets a property name string from a lambda expression to avoid the need
    /// to hard-code the property name in tests.
    /// </summary>
    public static string GetPropertyName<T>(Expression<Func<T>> expression)
    {
	    MemberExpression body = (MemberExpression)expression.Body;
	    return body.Member.Name;
    }
