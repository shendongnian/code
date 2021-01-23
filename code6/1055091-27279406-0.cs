    using System;
    using System.Text.RegularExpressions;
    					
    public class Program {
    	public static void Main() {
    		var input = "1 2 3 4 5 6";
    		Console.WriteLine("input:");
    		Console.WriteLine(input);
    		var output = Regex.Replace(input, " ", "\n");
    		Console.WriteLine("output:");
    		Console.WriteLine(output);
    	}
    }
