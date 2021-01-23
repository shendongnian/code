    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<MyObject> MyList = new List<MyObject>();
    		
    		for (int x = 1; x <= 10; x++)
    		{
    			MyObject obj = new MyObject();
    			obj.Id = x;
    			
    			MyList.Add(obj);					   
    		}
    		
    		//now show the list
    		
    		foreach(MyObject obj in MyList)
    		{
    			Console.WriteLine(obj.Id.ToString());
    		}
    	}
    }
    
    public class MyObject
    {
    	public int Id {get;set;} 	
    }
