    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
	    	byte[] bytes1 = { 97, 98, 99, 100 };
		    byte[] bytes2 = { 49, 50, 51, 52 };
		    
            // concat
		    byte[] bytes = bytes1.Concat(bytes2).ToArray();
		    // convert
		    string bytesAsString = Encoding.UTF8.GetString(bytes);
			
		    Console.WriteLine(bytesAsString);
		
	    }
    }
