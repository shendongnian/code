        public static class SaferMemberAccess
        	{
        
        	    private static int numericField = 1;
        	         private static object syncObj = new object( );
        
        	    public static void IncrementNumericField( )
        	   {
        	             lock(syncObj)              
                             {
        	               ++numericField;
        	             }
        	   }
        
        	    public static void ModifyNumericField(int newValue)
        	    {
        	             lock(syncObj)             
                             {
        	               numericField = newValue;
        	             }
        	    }
        
        	    public static int ReadNumericField( )
        	    {
        	             lock (syncObj)            
                             {
        	               return (numericField);
        	             }
        	    }
        	}
