    using System;
    using System.Collections.Generic;
    class Program
    {
       static void Main()
       {
	      Dictionary<string, int> dictionary =
	      new Dictionary<string, int>();
	     dictionary.Add("apple", 1);
	     dictionary.Add("windows", 5);
	     // See whether Dictionary contains this string.
	     if (dictionary.ContainsKey("apple"))
	    {
	        int value = dictionary["apple"];
	       Console.WriteLine(value);
	    }
	    // See whether it contains this string.
	    if (!dictionary.ContainsKey("acorn"))
	    {
	        Console.WriteLine(false);
	    }
      }
