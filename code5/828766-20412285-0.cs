    public class  MyClass
    {
    	public int Id{get;set;}
    	public string S{get;set;}
    	public double D{get;set;}
    }
    
    public static string[] GetPropsNamesArray<T>(Expression<Func<T,Object>> expr)
    {
    	var t = GetObjectType(expr);
    	var res = t.GetProperties(BindingFlags.Instance|BindingFlags.Public)
    	    .Select(pi => pi.Name)
    	    .ToArray();
    	return res;
    	
    }
    
    public static Type GetObjectType<T>(Expression<Func<T, object>> expr)
    {
        if ((expr.Body.NodeType == ExpressionType.Convert) ||
            (expr.Body.NodeType == ExpressionType.ConvertChecked))
        {
            var unary = expr.Body as UnaryExpression;
            if (unary != null)
                return unary.Operand.Type;
        }
        return expr.Body.Type;
    }
