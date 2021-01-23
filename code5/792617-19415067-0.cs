    public class ExprTest
    {
    	private readonly int value;
    	public ExprTest(int value)
    	{
    		this.value = value;
    	}
    
    	public Func<int> GetValueExpr()
    	{
    		var fieldExpr = Expression.Field(Expression.Constant(this), "value");
    		var lambda = Expression.Lambda<Func<int>>(fieldExpr);
    		return lambda.Compile();
    	}
    }
    
    var e = new ExprTest(5);
    int i = e.GetValueExpr()();    //i == 5
