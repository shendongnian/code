    using System;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		Random rnd = new Random();
    		List<int> AlreadyAskedQuestions = new List<int>();
    		for(int i = 0 ; i<10;i++)
    		{
    			int rn = rnd.Next(0,10);
    			while(AlreadyAskedQuestions.Contains(rn))
    			{
    				rn = rnd.Next(0,10);
    			}
    			AlreadyAskedQuestions.Add(rn);
    		}
    		
    		foreach(int i in AlreadyAskedQuestions)
    		{
    			Console.WriteLine(i);
    		}
    	}
    }
