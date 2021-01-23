    public class SomeClass
    {
    	public SomeClass(int i = 3, string str = "Default")
    	{
    	}
    }
    
    ConstructorInfo ci = typeof(SomeClass).GetConstructor(new[] { typeof(int), typeof(string) });
    var paramExprs = ci.GetParameters().Select(p => Expression.Constant(p.DefaultValue)).ToArray();
    var newExpr = Expression.New(ci, paramExprs);
