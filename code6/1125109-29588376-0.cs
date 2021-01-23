    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class Program
    {
    	public static void Main(){
    		var code = @"if(x=0)
    {
    x=10;
    }";
    		var tokens = new List<string>();
    		var token = new StringBuilder();
    		for(int i = 0; i < code.Length; i++)
    		{
    			char CurrentChar = code[i];
    			if(CurrentChar == '(')
    			{
    				tokens.Add(token.ToString());
    				token = new StringBuilder();
    			}
    			// Do checks for other tokens
    			else
    			{
    				token.Append(code[i]);
    			}
    		}
    		foreach(var tkn in tokens)
    		{
    			Console.WriteLine(tkn);
    		}
    	}
    }
