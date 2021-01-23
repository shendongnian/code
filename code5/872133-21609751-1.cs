    public static string GetPropName<TResult>(Expression<Func<TResult>> expression)
    { 
        MemberExpression body = (MemberExpression)expression.Body;
        return body.Member.Name;
    }
    string staticPropName = Test.GetPropName(()=> Test.Prop); 
   
