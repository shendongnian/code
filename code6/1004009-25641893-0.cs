    public static string SitecoreFieldName<TModel>(Expression<Func<TModel, object>> field)
    {
        var body = field.Body as MemberExpression;
        
        if (body == null)
        {
            return null;
        }
    
        var attribute = typeof(TModel).GetProperty(body.Member.Name)
            .GetCustomAttributes(typeof(SitecoreFieldAttribute), true)
            .FirstOrDefault() as SitecoreFieldAttribute;
    
        return attribute != null
            ? attribute.FieldName
            : null;
    }
