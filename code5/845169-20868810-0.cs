    public class Test
    {
    	public int myfield;
    	public static void Main()
    	{
    		// Make a parameter expression to represent the object
    		var argExpr = Expression.Parameter(typeof(Test), "a");
    		// Get the field of your object (the same way as in your first example)
    		var field = typeof(Test).GetField("myfield", BindingFlags.Public | BindingFlags.Instance);
    		// Make an expression accessing the field from the parameter
    		var fieldExpr = Expression.Field(argExpr, field);
    		// Compile the expression into a functor
    		var getter = (Func<Test,int>)Expression.Lambda(fieldExpr, argExpr).Compile();
    		// Construct a test object
    		var tmp = new Test {myfield = 123};
    		// Use a wrapper to avoid "boxing"/"unboxing" of "GetValue"
    		int res = getter(tmp);
    		Console.WriteLine("Res={0}", res);
    	}
    }
