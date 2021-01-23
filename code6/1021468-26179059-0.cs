    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var a = new Foo();
    		var b = new Foo2();
    		var res = a.GetType().CustomAttributes;
    		foreach(var i in res)
    		{
    			Console.WriteLine(i);
    		}
    		var res2 = b.GetType().CustomAttributes;
    		foreach(var i in res2)
    		{
    			Console.WriteLine(i);
    		}
    	}
    }
    
    [MyAttr(typeof(int))]
    public class Foo
    {
    }
    
    [MyAttr(Constants.Value,typeof(int))]
    public class Foo2
    {
    }
    
    public static class Constants
    {
    	public const int Value=1;
    }
    
    public class MyAttr:Attribute
    {
    	public Type Field {get;set;}
    	
    	public MyAttr(Type type)
    	{
    		this.Field=type;
    	}
    	public MyAttr(int a, Type type)
    	{
    		this.Field=type;
    	}
    }
