    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<Item> items = new List<Item>()
    			.AddAlso(new Item{ Id=1, Name="Ball", Description="Hello" })
    			.AddAlso(new Item{ Id=2, Name="Hat", Description="Test" });
    		
    		foreach(var item in items)
    			Console.WriteLine("Id {0} Name {1}, Description {2}",item.Id,item.Name,item.Description);
    	}
    }
    		   
    public static class Extensions
    {
    	public static List<T> AddAlso<T>(this List<T> list,T item)
    	{
    		list.Add(item);
    		return list;
    	}
    }
    		   
    public class Item
    {
    	public int Id{get;set;}
    	public string Name{get;set;}
    	public string Description{get;set;}
    }
