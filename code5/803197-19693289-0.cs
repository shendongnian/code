    public class MyClass<T> : DynamicObject
    {
    	private T property;
    
    	public override bool TryGetMember(GetMemberBinder binder, out object result)
    	{
    		if (binder.Name == typeof(T).Name)
    		{
    			result = property;
    			return true;
    		}
    		else
    		{
    			result = null;
    			return false;
    		}
    	}
    
    	public override bool TrySetMember(SetMemberBinder binder, object value)
    	{
    		if (binder.Name == typeof(T).Name && value is T)
    		{
    			property = (T)value;
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}
    }
