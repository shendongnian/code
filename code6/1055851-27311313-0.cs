    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var re = new Regex("((?<a>a)|(?<b>b))");
    		
    		var ma = re.Match("a");
    		Console.WriteLine("a in a: " + ma.Groups["a"].Success);
    		Console.WriteLine("b in a: " + ma.Groups["b"].Success);
    
    		ma = re.Match("b");
    		Console.WriteLine("a in b: " + ma.Groups["a"].Success);
    		Console.WriteLine("b in b: " + ma.Groups["b"].Success);
    	}
    }
