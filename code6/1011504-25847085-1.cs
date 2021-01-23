    public static void SetPropertyValue<T>(this T target, Expression<Func<T, string>> memberLamda, string value)
    {
        // Check if "new value" is null or empty and bail if so
        if (string.IsNullOrEmpty(value))
            return;
        var memberSelectorExpression = memberLamda.Body as MemberExpression;
        if (memberSelectorExpression != null)
        {
            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property != null)
            {
                // Get the existing value and compare against the new value 
                // Only set the property if it's different from the existing value
                if ((string)property.GetValue(target, null) != value)
                {
                    property.SetValue(target, value, null);
                }
            }
        }
    }
