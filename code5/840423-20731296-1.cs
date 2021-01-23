    void Main()
    {
	    Console.WriteLine (new Super().GetType().BaseType);
	    Console.WriteLine (new Sub().GetType().BaseType);
    }
    
    class Super { }
    class Sub : Super { }
