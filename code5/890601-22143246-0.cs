    IQueryable queryable = ...
    
    var methodCall = queryable.Expression as MethodCallExpression;
    
    if(methodCall != null)
    {
       var method = methodCall.Method;
       if(method.Name == "OfType" && method.DeclaringType == typeof(Queryable))
       {
          var type = method.GetGenericArguments().Single();
          Console.WriteLine("OfType<{0}>", type);
       }
    }
