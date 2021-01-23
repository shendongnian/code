    public static string DisplayAttribute<T>(this T obj, Expression<Func<T, string>> value)
    {
        var memberExpression = value.Body as MemberExpression;
        var attr = memberExpression.Member.GetCustomAttributes(typeof(DisplayNameAttribute), true);
        if (attr.Length > 0)
        {
            return ((DisplayNameAttribute)attr[0]).Title;
        }
        // Return some default value
        return memberExpression.Member.Name;
    }
