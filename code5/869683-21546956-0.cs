    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		decimal d = 123456789.456m;
    		int i = (int) d;
    		int cnt = 1;  
            // Use not equal Operator in order to handle number < 0 correctly
    		while ((i = i / 10) != 0)  
    		    cnt++;
    		Console.WriteLine(cnt.ToString());
    	}
    }
