    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		DateTime dt = new DateTime();
    		DateTime dt2 = new DateTime();
    		
    		dt = DateTime.Now;
    		dt2 = dt.AddDays(20);
    		
    		
    		TimeSpan ts = dt2.Subtract(dt);
    		
    		Console.WriteLine(dt.ToString());
    		Console.WriteLine(dt2.ToString());
    		
    		if(ts.Days > 30)
    		{
    		Console.WriteLine("It has been at least a month since last check up");
    		}
    		else
    		{
    			Console.WriteLine("It has been "+ ts.Days+" days since last check up");
    		}
    			
    	}
    }
