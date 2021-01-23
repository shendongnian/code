    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var data = new List<int>(5){1,2,3,4,5};
    		var result = new List<int>(5);
    		for(int i=0;i<5;i++)
    		{
    			result.Add(data[(i+2)%data.Count]);
    		}
    		for(int i=0;i<result.Count;i++)
    		{
    			Console.WriteLine(string.Format("{0}\n",result[i]));
    		}
    	}
    }
