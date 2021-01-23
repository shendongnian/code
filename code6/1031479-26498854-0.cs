    class Dog
    {
        // signature without arguments
    	public void bark()
    	{
    		Console.WriteLine("Empty method");
    	}
    	
        // other signature for the method, which takes a string argument
    	public void bark(string arg)
    	{
    		Console.WriteLine("Bark {0}", arg);
    	}
    }
    
