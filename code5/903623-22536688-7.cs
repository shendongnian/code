    public class Container
    {
    	private B _B;
        public B B 
    	{ 
    		get
    		{
    			return _B;
    		}
    		set
    		{
    			if (value != null)
    			{
    				value._ShouldSerializeProperty1 = false;
    				value._ShouldSerializeProperty2 = true;
    			}
    			_B = value;
    		}
    	}
    	
    	private C _C;
    	public C C
    	{
    		get
    		{
    			return _C;
    		}
    		set
    		{
    			if (value != null)
    			{
    				value._ShouldSerializeProperty1 = true;
    				value._ShouldSerializeProperty2 = false;
    			}
    			_C = value;
    		}
    	}
    }
