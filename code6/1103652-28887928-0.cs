    using System;
    
    public class Parent
    {
    	public virtual string HelloWorld()
    	{
    		return "Hello world";
    	}
    }
    
    public class Child : Parent
    {
    	public string HelloWorld(string name)
    	{
    		return HelloWorld() + " from " + name;
    	}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var child = new Child();
    		Console.WriteLine(child.HelloWorld());
    		Console.WriteLine(child.HelloWorld("Shaun"));
    	}
    }
