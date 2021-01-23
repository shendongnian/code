    using System;
	using System.Collections.Generic;
	class Program
	{
	    static void Main()
	    {
		// Use a dictionary with an int key.
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		    dictionary.Add(04634, "AMBASAMUDRAM");
		    dictionary.Add(04253, "ANAMALI");
		    dictionary.Add(04153, "ARAKANDANALLUR");
		// You can look up the int in the dictionary.
		if (dictionary.ContainsKey(04634))
		{
		    String value = dictionary[04634];
		    Console.WriteLine(value);
		}
	    }
	}
