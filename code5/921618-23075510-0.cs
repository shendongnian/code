    using System;
    
    public interface IMyInterface<T>
    {
    	T Method1(T input);
    }
    
    public class MyImpl : IMyInterface<int>
    {
    	public int Method1(int input)
    	{
    		return input * 2;
    	}
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		// Concrete type that implements the interface
    		Type implType = typeof(MyImpl);
    		// Type of generic interface
    		Type genType = typeof(IMyInterface<>);
    		// Interface for int
    		Type concType = genType.MakeGenericType(typeof(int));
    		// Create instance
    		object inst = Activator.CreateInstance(implType);
    		// Retrieve member that you want to call
    		var member = concType.GetMethod("Method1");
    		// Invoke member on instance
    		var result = member.Invoke(inst, new object[] { 123 });
    		Console.WriteLine("{0} --> {1}", 123, result);
    	}
    }
