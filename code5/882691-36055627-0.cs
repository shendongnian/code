    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main(string[] args)
        {
    		Cache.AddCacheObj<Dog>(new Dog());
    		Cache.AddCacheObj<Cat>(new Cat());
    		
            var cat = Cache.GetCachedObj<Dog>();
    		Console.WriteLine("Cat: {0}", cat);
    		
            var dog = Cache.GetCachedObj<Cat>();
    		Console.WriteLine("Dog: {0}", dog);		
        }
    }
    
    public static class Cache
    {
        static Dictionary<Type, List<Animal>> dict = new Dictionary<Type, List<Animal>>();
    
        public static T GetCachedObj<T>() where T: Animal
        {
    		List<Animal> list;
    		if (dict.TryGetValue(typeof(T), out list))
    		{
    			return list.FirstOrDefault() as T;
    		}
            return null;
        }
    	
    	public static void AddCacheObj<T>(T obj) where T: Animal
    	{
    		List<Animal> list;
    		if (!dict.TryGetValue(typeof(T), out list))
    		{
    			list = new List<Animal>();
    			dict[typeof(T)] = list;
    		}
    		list.Add(obj);
    	}
    }
    
    public class Animal
    {
    	public override string ToString()
    	{
    		return "This is a " + this.GetType().ToString();
    	}
    }
    
    public class Dog : Animal
    {
    
    }
    
    public class Cat : Animal
    {
    
    }
