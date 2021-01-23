    public static List<SelectListItem> ToSelectList<T>(this IQueryable<T> query, Expression<Func<T, object>> value, Expression<Func<T, string>> text)
    {
        var valueSrc = getProperty(value);
        var textSrc  = getProperty(text);    
        var x = Expression.Parameter(typeof(T),"x");
        var type = typeof(SelectListItem);
        var textProp = type.GetProperty("Text");
        var valueProp = type.GetProperty("Value");
        
        // x.valueSrc
        Expression valueExpr = Expression.Property(x,valueSrc);
        
        // (x.valueSrc).ToString()
        if (valueExpr.Type == typeof(int))
        {
             var toStringMethod = typeof(int).GetMethod("ToString",Type.EmptyTypes);
             valueExpr = Expression.Call(valueExpr,toStringMethod);
        }
        
        //x => new SelectListItem { Text = x.textSrc, Value = valueExpr }
        var lambda = Expression.Lambda<Func<T,SelectListItem>>(
                        Expression.MemberInit(
                            Expression.New(type),
                            Expression.Bind(textProp,Expression.Property(x,textSrc)),
                            Expression.Bind(valueProp,valueExpr)),
                        x);
        
        return query.Select(lambda).ToList();
    }
    
    static PropertyInfo getProperty(LambdaExpression exp)
    {
        var body = exp.Body;
        
        //x => (object) x.Property
        var ue = body as UnaryExpression;
        if (ue != null)
            body = ue.Operand;
            
        return (PropertyInfo) ((MemberExpression) body).Member;        
    }
    
