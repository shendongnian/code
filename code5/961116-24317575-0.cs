    public class MyClass
    {
    	private string Value { get; set; }
    
    	public static bool operator ==(MyClass left, object right)
    	{
    		// Test if both are null or the same instance, then return true
    		if (ReferenceEquals(left, right))
    			return true;
    
    		// If only one of them null return false
    		if (((object)left == null) || ((object)right == null))
    			return false;
    
    		// Test value
    		return left.Equals(right);
    	}
    }
