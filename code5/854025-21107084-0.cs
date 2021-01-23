    using System;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
    	// Input string.
    	const string input = "Dot Net Perls";
    
    	// Invoke GetBytes method.
    	// ... You can store this array as a field!
    	byte[] array = Encoding.ASCII.GetBytes(input);
    
    	// Loop through contents of the array.
    	foreach (byte element in array)
    	{
    	    Console.WriteLine("{0} = {1}", element, (char)element);
    	}
        }
    }
