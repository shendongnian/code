    using System;
    
    public abstract class MyBase
    {
    	public abstract bool GetValue(bool value = true);
    }
    
    public class MyDerived : MyBase
    {
    	public override bool GetValue(bool value = false)
    	{
    		return value;
    	}
    }
    
    public class Test
    {
    	public static void Main()
    	{
    		var derived = new MyDerived();
    		Console.WriteLine("Value = {0}", derived.GetValue());
    		MyBase myBase = derived;
    		Console.WriteLine("Value = {0}", myBase.GetValue());
    	}
    }
