    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		A a = new A();
    		// Noticed that Next() is called twice
    		Console.WriteLine(a.Next(1));
    		Console.WriteLine(a.Next(1));
    				
    		// An alternative, that uses extension methods only
    		var withCache = a.AddCaching<A,int,int>(x => x.Next);
    		
    		// Notice that Next() is only called once
    		Console.WriteLine(withCache(1));
    		Console.WriteLine(withCache(1));
    	}
    }
    
    public class A
    {
    	public int Next(int n)
    	{
    		Console.WriteLine("Called Next("+n+")");
    		return n + 1;
    	}
    }
    
    public static class ExtensionMethods
    {	
    	public static Func<TKey,TVal> AddCaching<T,TKey,TVal>(this T wrapped, Func<T,Func<TKey,TVal>> fetcher)
    	{
    		var cache = new Dictionary<TKey, TVal>();
    		return k =>
    		{
    			if (!cache.ContainsKey(k)) cache[k] = fetcher(wrapped)(k);
    			return cache[k];
    		};		
    	}
    }
