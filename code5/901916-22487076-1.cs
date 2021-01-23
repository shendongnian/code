    using System;
    using System.Collections.Generic;
    using System.Text;
    					
    public class Program
    {
    	public static void Main()
    	{
    		/*"MyFavouriteChocIsDARKChocalate" should return "My Favourite Choc Is DARK Chocalate"*/
    		var input = "MyFavouriteChocIsDARKChocalate";
    		var split = SplitOnCaps(input);
    		Console.WriteLine(input + " --> " + split);
    		var match = "My Favourite Choc Is DARK Chocalate";
    		
    		Console.WriteLine(split == match ? "Match" : "No Match");		
    	}
    	
    	public static string SplitOnCaps(string s)
    	{
    		var splits = new List<int>();
    		
    		var chars = s.ToCharArray();
    		
    		for(var i=1; i<chars.Length-1; i++)
    		{
    			if (IsCapital(chars[i]) && !IsCapital(chars[i+1]) ||
    			   IsCapital(chars[i]) && !IsCapital(chars[i-1]))
    			{
    				splits.Add(i);
    			}
    		}
    
    		var sb = new StringBuilder();
    
    		var lastSplit = 0;
    		foreach(var split in splits)
    		{
    			sb.Append(s.Substring(lastSplit, split - lastSplit) + " ");
    			lastSplit = split;
    		}
    		sb.Append(s.Substring(lastSplit));
    		
    		return sb.ToString();
    	}
    	public static bool IsCapital(char c)
    	{
    		var i = (int)c;
    		return i>=65 && i<=90;
    	}
    }
