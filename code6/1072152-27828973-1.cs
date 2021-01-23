    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Please enter a number:");
    		var number=Convert.ToInt32(Console.ReadLine());
    		for(int i=0; i < number; i++)
    		{			
    			for(int j=0; j < number; j++)
    			{			
    				if(i==0 || i == number-1 || j==0 || j == number-1)
    					Console.Write("*");	
    				else
    					Console.Write(" ");
    			}
    			Console.Write("\n");
    		}
    	}
    }
