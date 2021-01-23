    using System;
    using System.Collections.Generic;
 
    public class Test
    {
	    public static void Main()
	    {
		    var n = EqualityComparer<string>.Default.GetHashCode(null);
	    	Console.WriteLine(n);
	    }
    }
