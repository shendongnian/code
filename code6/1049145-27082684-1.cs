    using System.IO;
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
        // This is the input string we are replacing parts from.
    	string input = "D2015987.txt";
    
    	// Use Regex.Replace to replace the pattern in the input.
    	string output = Regex.Replace(input, @"^(\w)\d+(\d{3})\.txt$", "$1$2");
    
    	// Write the output.
    	Console.WriteLine(input);
    	Console.WriteLine(output);
        }
    }
