    void Main()
    {
    	var a = new Class1();
    	var b = new Class2();
    	
    	try
    	{	        
    		a.Run("Foo");
    		b.Run("Bar", "Yoda");
    		b.Run("Bat"); // throws exception
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine (ex.Message);
    	}
    }
    
    class Base
    {
    	public void Run(string commandName, params object[] args)
    	{
    		var method = this.GetType().GetMethod(commandName);
    		if(method != null)
    			method.Invoke(this, args);
    		else
    			throw new Exception("the command " + commandName + " does not exist on " + this.GetType().Name);
    	}
    }
    
    class Class1 : Base
    {
    	public void Foo()
    	{
    		Console.WriteLine ("I am foo");
    	}
    }
    
    class Class2 : Base
    {
    	public void Bar(string str)
    	{
    		Console.WriteLine ("I am {0}", str);
    	}
    }
