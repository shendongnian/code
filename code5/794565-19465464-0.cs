    void Main()
    {
    	DateTime a = new DateTime(2005, 05, 05);
    	DateTime b = a;
    
    	Console.WriteLine (a);
    	Console.WriteLine (b);
    	
    	a = new DateTime(2012, 05, 05);
    	Console.WriteLine (a);
    	Console.WriteLine (b);
    }
