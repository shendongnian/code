    public void MyMethod<T>(Expression<Func<T,TResult>> expr, ... ){
        var expression = (MemberExpression)expr.Body;
        var name = expression.Member.Name;
        // .. the rest here using "name"
    }
    
