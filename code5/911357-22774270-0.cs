    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    	    bool b = checkValue("01, FF, 3E, 27, 7F");		// textBlock.Text
    		Console.WriteLine(b);
    	}
    	
    	static bool checkValue(string s)
    	{
    		string[] tab = s.Split(new string[] { ", " }, StringSplitOptions.None ); // split string with ", " as a delimiter
    		foreach (var item in tab)
    			if (!IsHex(item))
    		        return false;
    		return true;
    	}
        
    	private static bool IsHex(string s)
        {
    		if (s.Length != 2) // Check if we have two values
    			return false;
            foreach(var c in s)
            {
    			// check for valid letter (upper and lower) and digit
                if(!((c >= '0' && c <= '9') || 
                    (c >= 'a' && c <= 'f') || 
                    (c >= 'A' && c <= 'F')))
                    return false;
            }
            return true;
        }
    }
        
