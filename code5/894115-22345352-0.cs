    public class ExpressionTools
    {
    	public string GetLastInstanceName<TProp, TDelegate>(Expression<Func<TProp, TDelegate>> expression)
    	{
    		var unaryExpression = (UnaryExpression)expression.Body;
    		var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
    		var methodInfoExpression = (MemberExpression)methodCallExpression.Arguments.Reverse().Skip(1).First();
    		var instanceName = methodInfoExpression.Member.Name;
    
    		return instanceName;
    	}
    
    		public string GetMethodName<TProp, TDelegate>(Expression<Func<TProp, TDelegate>> expression)
    	{
    		var unaryExpression = (UnaryExpression)expression.Body;
    		var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
    		var methodInfoExpression = (ConstantExpression)methodCallExpression.Arguments.Last();
    		var methodInfo = (MemberInfo)methodInfoExpression.Value;
    
    		return methodInfo.Name;
    	}
    }
