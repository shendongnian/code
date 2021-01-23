    void Main()
    {
    	var super = new Super();
    	Console.WriteLine (super.GetType().BaseType);
    	var sub = new Sub();
    	Console.WriteLine (sub.GetType().BaseType);
    }
    
    class Super { }
    class Sub : Super { }
