    using System;
    using System.Collections.Generic;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
    	List<int> safePrimes = new List<int>(); // Create list of ints
    	safePrimes.Add(5); // Element 1
    	safePrimes.Add(7); // Element 2
    	safePrimes.Add(11); // Element 3
    	safePrimes.Add(23); // Element 4
    
    	StringBuilder builder = new StringBuilder();
    	foreach (int safePrime in safePrimes)
    	{
    	    // Append each int to the StringBuilder overload.
    	    builder.Append(safePrime).Append(" ");
    	}
    	string result = builder.ToString();
    	Console.WriteLine(result);
        }
    }
