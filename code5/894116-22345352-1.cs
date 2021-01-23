    public class Verifier
    {
    	public void Verify<TDelegate>(Expression<Func<KnownType, TDelegate>> methodExpression)
    	{
    		var tools = new ExpressionTools();
    		var moduleName = tools.GetLastInstanceName(methodExpression);
    		var methodName = tools.GetMethodName(methodExpression);
    
    		// My logic.
    	}
    }
