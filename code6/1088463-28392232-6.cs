    class Class1
    {
    	private int number;
    
    	public int Number
    	{
    		get { return number; }
    		set
    		{
    			if (value > 0)
    				number = value;
    			else
    				number = 0;
    		}
    	}
        // If you do provide a constructor (any constructor with any signature), 
        // the parametrless constructor will not be generated
        public Class1()
    	{
    	}
    
    	public Class1(int number)
    	{
    		Number = number;
    	}
    }
