    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		// Choose Mustard & SecretSauce
    		Condiments selected = Condiments.Mustard | Condiments.SecretSauce;
    		
    		Console.WriteLine(selected);
    		
    		
    		// Is SecretSauce selected
    		bool has = selected.HasFlag(Condiments.SecretSauce);
    		
    		Console.WriteLine(has);
    			
    	}
    }
    
    [Flags]
    public enum Condiments
    {
    	Mayonaise = 0x01,
    	Mustard = 0x02,
    	Ketchup = 0x04,
    	SecretSauce = 0x08,
    }
