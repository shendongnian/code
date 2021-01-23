    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var maxAttempts = 5;
    		var correctAnswer = "Edam";
    		for(int actualAttempts = 1; actualAttempts <= maxAttempts; ++actualAttempts)
    		{
    			Console.WriteLine("What is the only cheese that's made backwards?");
    			Console.WriteLine("Attempt #" + actualAttempts);
    			var answer = Console.ReadLine();
    			if(answer.Equals(correctAnswer))
    			{
    				Console.WriteLine("Correct!");
    			    break;
    			}
    			switch(actualAttempts)
    			{
    				case 1: 
    					Console.WriteLine("Whoa. Nice try.");
    					break;
    				
    				case 2: 
    					Console.WriteLine("Nope. Wrong.");
    					break;
    				
    				case 3: 
    					Console.WriteLine("Incorrect sir!");
    					break;
    				
    				case 4: 
    					Console.WriteLine("Still not the correct answer.");
    					break;
    				
    				case 5: 
    					Console.WriteLine("...and your done.");
    					break;
    				
    				default :
    					break;
    			}
    		}
    	}
    }
