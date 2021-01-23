    using System;
    using System.Linq;
    public class Test
    {
	    public static void Main()
	    {
            Sum(8,3,3);
	    }
	
	    public static void Sum(params int[] number)
        {
    	    Console.WriteLine("For the list <{0}>, the sum of its elements is: {1}", 
    	    string.Join(", ", number.Select(x => x.ToString()).ToArray()), 
    	    number.Sum());
        }   
    }
