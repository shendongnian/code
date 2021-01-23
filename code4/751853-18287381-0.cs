    public static string SeparateByCommas<T, TProp>(this IEnumerable<T> source, Expression<Func<T, TProp>> expression)
    {
        var memberExpression = expression.Body as MemberExpression;
        if (memberExpression == null)
            return string.Empty;
        
        var propName = memberExpression.Member.Name;
        return source.Aggregate(new StringBuilder(), (builder, t) =>
               {
                   builder.Append(typeof (T).GetProperty(propName).GetValue(t).ToString());
                   builder.Append(",");
                   return builder;
               }).ToString();
    }
    var test = new List<Brand>
    {
       new Brand
       {
         Number = 1,
         Name = "a"
       },
       new Brand
       {
         Number = 2,
         Name = "b"
       }
    };
        
        
    string separateByCommas = test.SeparateByCommas(brand => brand.Name);
