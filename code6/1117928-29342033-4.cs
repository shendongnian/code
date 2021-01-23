    LambdaExpression Build(MethodInfo methodInfo)
    {
      // This + all the method parameters.
      var parameters = 
        new [] { Expression.Parameter(typeof(YourClassBase)) }
        .Union(methodInfo.GetParameters().Select(i => Expression.Parameter(i.ParameterType)))
        .ToArray();
    
      return
        Expression.Lambda
        (
          Expression.Call
          (
            ((Func<MethodInfo, YourClassBase, object[], object>)InvokeInternal).Method,
            Expression.Constant(methodInfo, typeof(MethodInfo)),
            parameters[0],
            Expression.NewArrayInit(typeof(object), parameters.Skip(1).Select(i => Expression.Convert(i, typeof(object))).ToArray())
          ),     
          parameters
        );
    }
    
    public static object InvokeInternal(MethodInfo method, YourClassBase @this, object[] arguments)
    {
      var script = @"
        var calc = new Com.Example.FormCalculater();
        var result = calc.{0}({1});";
      
      script = string.Format(script, method.Name, string.Join(", ", arguments.Select(i => Convert.ToString(i))));
      
      @this.ScriptEngine.Evaluate(script);
      
      return (object)Convert.ChangeType(@this.ScriptEngine.Evaluate("result"), method.ReturnType);
    }
