    using System;
    using System.Collections.Generic;
    
    public static class StringExtenssion 
    {
    	public static int IndexOfNth(this string input, string value, int startIndex, int nth)
    	{
    	    if (nth < 1)
            	throw new NotSupportedException("Param 'nth' must be greater than 0!");
        	if (nth == 1)
    	        return input.IndexOf(value, startIndex);
        	var idx = input.IndexOf(value, startIndex);
        	if (idx == -1)
            	return -1;
        	return input.IndexOfNth(value, idx + 1, --nth);
    	}
    }
    
    public class Program
    {
    	public static string GetColumnDataValue(string row, int column)
    	{
    		int startIndex = 0;
    		int length = row.Length;
    		if (column != 0)
    			startIndex = row.IndexOfNth(",", 0, column) + 1;
    		
    		var indexOfNextComma = row.IndexOf(",", startIndex);
    		if (indexOfNextComma == -1)
    			length = row.Length - startIndex - 1;
    		else
    			length = indexOfNextComma - startIndex;
    		
    		return row.Substring(startIndex, length);
    	}
    	
    	public static void Main()
    	{		
    		List<string> list = new List<string> {
    			"2,Sam,500.00",
            	"6,Mike,400.00",
            	"8,Robert,156.00",
            	"3,Steve,100.85",
            	"9,Anderson,234.90",
    		};
    		
    		var sortBy = 1;
    		
    		list.Sort((a,b) => GetColumnDataValue(a, sortBy).CompareTo(GetColumnDataValue(b, sortBy)));
    		foreach(var row in list)
    		{
    			Console.WriteLine(row);
    		}
    	}
    }
