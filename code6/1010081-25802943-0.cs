    public static string GetPropertyName<T, TPropValue>(this Expression<Func<T, TPropValue>> propertySelector) where T : class
    {
        Condition.Requires(propertySelector, "propertySelector").IsNotNull();
    
        var memberExpr = propertySelector.Body as MemberExpression;
        if (memberExpr == null)
             throw new ArgumentException("Provider selector is not property selector.");
    
        var propInfo = memberExpr.Member as PropertyInfo;       
        if (propInfo == null)
             throw new NotSupportedException("You can properties only.");
    
        return propInfo.Name;
    }
    
    protected void RaisePropertyChanged(Expression<Func<MyClass, string>> propSelector) 
    {  
       if (PropertyChanged != null)
       {
           var propertyName = propertySelecotr.GetPropertyName();
           PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }
    }
