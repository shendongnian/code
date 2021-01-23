    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		string formula = "AB1+FB+100";
    		var length = formula.Length;
    		List<string> variables = new List<string>();
    		List<char> operators = new List<char>{'+', '-', '*', '/', ')', '('};
    		List<char> numerals = new List<char>{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
    
    		int count = 0;
    		string character = string.Empty;
    		char prev_char = '\0';
    		
    		for (int i = 0; i < length; i++)
    		{
    			bool is_operator = operators.Contains(formula[i]);
    			bool is_numeral = numerals.Contains(formula[i]);
    			bool is_variable = !(is_operator || is_numeral);
    			bool was_variable = character.Contains(prev_char);
    				
    			if (is_variable || (was_variable && is_numeral) )
    				character += formula[i];
    			else
    			{
    				if (!string.IsNullOrWhiteSpace(character))
    					variables.Add(character);
    				character = string.Empty;
    				count = i;
    			}
    			
    			prev_char = formula[i];
    		}
    
    		if (!string.IsNullOrWhiteSpace(character))
    			variables.Add(character);
    		
    		foreach (var item in variables)
    			Console.WriteLine(item);
    		Console.WriteLine();
    		Console.WriteLine();
    	}
    }
