    void PrintName(Expression<Func<Foo, bool>> func)
    {
    	var methodCall = func.Body as MethodCallExpression;
    	var property =  methodCall.Object as MemberExpression;
    	Console.WriteLine (property.Member.Name);
    }
    PrintName(u => u.FirstName.Contains( "ues" )); //prints FirstName
