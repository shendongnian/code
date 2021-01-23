    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
    	// ... Input string.
    	string input = "C:\Development\TestEnvironment\VIdeo\MyVideo.mp3";
    
    	// ... One or more digits.
    	Match m = Regex.Match(input, "(?i)(?x)\\\\([\\w\\.]+)");
    
    	// ... Write value.
    	Console.WriteLine(m.Value);
        }
    }
