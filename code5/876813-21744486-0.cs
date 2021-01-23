    public static class HugeClassWrapper
    {
    	private static HugeClass hugeClass = new HugeClass();
    	
    	public static TResult Invoke<TResult>(string methodName, params object[] args)
    	{
    		// Do the common tasks before executing the method
    		CommonOperationBefore();
    		// Invoke the function
    		TResult result = (TResult)hugeClass.GetType()
    								.GetMethod(methodName).Invoke(hugeClass, args);
    		// Do the common tasks after executing the method
    		CommonOperationAfter();
    		return result;
    	}
    	
    	public static void Invoke(string methodName, params object[] args)
    	{
    		// Common tasks before executing 
    		CommonOperationBefore(); 	
    		// Invoke the method
    		hugeClass.GetType().GetMethod(methodName).Invoke(hugeClass, args);	
    		// Common tasks after executing 
    		CommonOperationAfter();		
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
