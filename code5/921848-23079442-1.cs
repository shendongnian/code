    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	// This is the input string we are replacing parts from.
    	string input = "<area href='#' title='name' shape='poly' coords='38,23,242'/>";
    
    	// Use Regex.Replace to replace the pattern in the input.
    	// ... The pattern N.t indicates three letters, N, any character, and t.
    	string output = Regex.Replace(input, "(?<=title=')[^']+", "something");
    
    	// Write the output.
    	Console.WriteLine(input);
    	Console.WriteLine(output);
        }
    }
