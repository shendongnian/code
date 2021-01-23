    public static string GetXPath<T, TProp>(Expression<Func<T, TProp>> expr)
    {
        var me = expr.Body as MemberExpression;
        if (me != null)
        {
            var attr = (XPathAttribute[])me.Member.GetCustomAttributes(typeof(XPathAttribute), true);
            if (attr.Length > 0)
            {
                return attr[0].Value;
            }
        }
        return string.Empty;
    }
