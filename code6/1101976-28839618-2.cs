    public static List<SelectListItem> ToSelectList<T>(this IQueryable<T> query, Expression<Func<T, string>> value, Expression<Func<T, string>> text)
    {
        var valueSrc = (PropertyInfo) ((MemberExpression)(value.Body)).Member;
        var textSrc  = (PropertyInfo) ((MemberExpression)(text.Body)).Member;    
        var x = Expression.Parameter(typeof(T),"x");
        var type = typeof(SelectListItem);
        var textProp = type.GetProperty("Text");
        var valueProp = type.GetProperty("Value");
        
        //x => new SelectListItem { Text = x.textSrc, Value = x.valueSrc }
        var lambda = Expression.Lambda<Func<T,SelectListItem>>(
                        Expression.MemberInit(
                            Expression.New(type),
                            Expression.Bind(textProp,Expression.Property(x,textSrc)),
                            Expression.Bind(valueProp,Expression.Property(x,valueSrc))),
                        x);
        
        return query.Select(lambda).ToList();
    }
