    using System;
    
    class Program
    {
        static void Main()
        {
    	string[] arr = new string[4]; // Initialize
    	arr[0] = "uno";               // First element
    	arr[1] = "dos";               // Second
    	arr[2] = "tres";              // Third
    	arr[3] = "cuatro";            // Fourth
    
    	// Loop over strings
    	for (int i = 0; i < arr.Length; i++)
    	{
    	    string s = arr[i];
    	    Console.WriteLine(s);
    	}
    
    	// Bonus: Loop over strings backwards
    	for (int i = arr.Length - 1; i >= 0; i--)
    	{
    	    string s = arr[i];
    	    Console.WriteLine(s);
    	}
        }
    }
