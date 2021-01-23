    public static B GetProperty<T, B>(this Expression<Func<T, B>> propertySelector, T target) where T : class
    {
        if (target == null)
        {
            throw new ArgumentNullException("target");
        }
    
        if (propertySelector == null)
        {
            throw new ArgumentNullException("propertySelector");
        }
    
        var memberExpression = propertySelector.Body as MemberExpression;
        if (memberExpression == null)
        {
            throw new NotSupportedException("Only member expression is supported.");
        }
    
        var propertyInfo = memberExpression.Member as PropertyInfo;
        if (propertyInfo == null)
        {
            throw new NotSupportedException("You can select property only. Currently, selected member is: " +
                                            memberExpression.Member);
        }
    
        return (B)propertyInfo.GetValue(target);
    }
    
    public static void SetProperty<T, B>(this Expression<Func<T, B>> propertySelector, T target, B value)
    {
        SetObjectProperty(target, propertySelector, value);
    }
    
    public static void SetObjectProperty<T, B>(T target, Expression<Func<T, B>> propertySelector, object value)
    {
        if (target == null)
        {
            throw new ArgumentNullException("target");
        }
    
        if (propertySelector == null)
        {
            throw new ArgumentNullException("propertySelector");
        }
    
        var memberExpression = propertySelector.Body as MemberExpression;
        if (memberExpression == null)
        {
            throw new NotSupportedException("Cannot recognize property.");
        }
    
        var propertyInfo = memberExpression.Member as PropertyInfo;
        if (propertyInfo == null)
        {
            throw new NotSupportedException("You can select property only. Currently, selected member is: " + memberExpression.Member);
        }
    
        propertyInfo.SetValue(target, value);
    }
