    public static class Consts
    {
    	private const string _name = "Foo";
    	private static int _nameCount = 0;
    
    	public static string Name
    	{
    		get
    		{
    			if( _nameCount++ > 1 )
    			{
    				throw new Exception( "Cannot use Name more than once." );
    			}
    			return _name;
    		}
    	}
    }
