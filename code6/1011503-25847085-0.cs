    public static void SetPropertyValue<T>(this T target, Expression<Func<T, string>> memberLamda, string value)
    {
        if (string.IsNullOrEmpty(value))
            return;
        var memberSelectorExpression = memberLamda.Body as MemberExpression;
        if (memberSelectorExpression != null)
        {
            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property != null)
            {
                property.SetValue(target, value, null);
            }
        }
    }
