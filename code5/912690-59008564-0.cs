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
    				
    		// Works now :)
    		var withCache = a.Next.AddCaching<int,int>();
    		withCache = a.Next.AddCaching();
    		
    		// Notice that Next() is only called once
    		Console.WriteLine(withCache(1));
    		Console.WriteLine(withCache(1));
    	}
    }
    
    public class A
    {
    	public Func<int,int> Next;
    	
    	public A()
    	{
    		Next = NextInternal;	
    	}
    	
    	private int NextInternal(int n)
    	{
    		Console.WriteLine("Called Next("+n+")");
    		return n + 1;
    	}
    }
    
    public static class ExtensionMethods
    {
    	public static Func<TKey,TVal> AddCaching<TKey,TVal>(this Func<TKey,TVal> fetcher)
    	{
    		var cache = new Dictionary<TKey, TVal>();
    		return k =>
    		{
    			if (!cache.ContainsKey(k)) cache[k] = fetcher(k);
    			return cache[k];
    		};
    	}
    }
