    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	private static string[] productCodes = new[] { 
    		"MD0133776311I",
    		"M10133776311I",
    		"M20133776311I"
    	};
    
    	private static Dictionary<char, char> replacementMap = new Dictionary<char, char> {
    		{ '1', 'I' },
    		{ '2', 'S' },
    	};
    
    	private static Regex startsWithTwoLettersRegex = new Regex("^([A-Z]{2})");
    
    	public static void Main()
    	{
    		foreach (var code in productCodes)
    		{
    			Console.Write("{0} -> ", code);
    			if (!startsWithTwoLettersRegex.Match(code).Success)
    			{
    				Console.WriteLine(FixProductCode(code));
    			}
    			else
    			{
    				Console.WriteLine("OK!");	
    			}
    		}
    	}
    	
    	static string FixProductCode(string code)
    	{
    		StringBuilder sb = new StringBuilder(code);
    		sb[1] = replacementMap[code[1]];
    		return sb.ToString();
    	}
    }
