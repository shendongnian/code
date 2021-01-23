    public class NumericComparer: IComparer<string>
    {
    	public int Compare(string s1, string s2)
    	{
    		if (IsNumeric(s1) && IsNumeric(s2))
    		{
    			if (Convert.ToInt32(s1) > Convert.ToInt32(s2)) return 1;
    			if (Convert.ToInt32(s1) < Convert.ToInt32(s2)) return -1;
    			if (Convert.ToInt32(s1) == Convert.ToInt32(s2)) return 0;
    		}
    	}
    		
    	private static bool IsNumeric(string value)
    	{
    		try 
    		{
    			int i = Convert.ToInt32(value);
    			return true; 
    		}
    		catch (FormatException) 
    		{
    			return false;
    		}
    	}
    }
