    public class Parent
    {        
    	public virtual string HelloWorld()
    	{
    		return "Hello world";
    	}
    	
    	public string GoodbyeWorld()
    	{
    		return "Goodbye world";
    	}
    }
    
    public class Child : Parent
    {
         // override: exact same signature, parent method must be virtual
    	public override string HelloWorld()
    	{
    		return "Hello World from Child";
    	}
    	
         // overload: same name, different order of parameter types
    	public string GoodbyeWorld(string name)
    	{
    		return GoodbyeWorld() + " from " + name;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var parent = new Parent();
    		var child = new Child();
    		Console.WriteLine(parent.HelloWorld());
    		Console.WriteLine(child.HelloWorld());
    		Console.WriteLine(child.GoodbyeWorld());
    		Console.WriteLine(child.GoodbyeWorld("Shaun"));
    	}
    }
