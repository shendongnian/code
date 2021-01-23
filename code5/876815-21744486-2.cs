    public static class HugeClassWrapper
    {
    	private static HugeClass hugeClass = new HugeClass();
    	
    	public static void Invoke(Expression<Action<HugeClass>> expression)
    	{
    		CommonOperationBefore();	
    		expression.Compile().Invoke(hugeClass);	
    		CommonOperationAfter();
    	}
    
    	public static TResult Invoke<TResult>(Expression<Func<HugeClass, TResult>> expression)
    	{
    		CommonOperationBefore();	
    		TResult result = (TResult)expression.Compile().Invoke(hugeClass);
    		CommonOperationAfter();
    		return result;
    	}
    	
    	private static void CommonOperationBefore()
    	{
    		// your common operations...
    	}
    	private static void CommonOperationAfter()
    	{
    		// your common operations...
    	}
    }
