    /// <summary>
    /// Compares two alphanumeric version numbers.
    /// </summary>
    public class AlphanumericVersionComparer : IComparer<string>
    {
    	/// <summary>
    	/// Compares two alphanumeric version numbers and returns a value
    	/// indicating whether one is less than, equal to, or greater than the other.
    	/// </summary>
    	/// <param name="x">The first alphanumeric version number to compare.</param>
    	/// <param name="y">The second alphanumeric version number to compare.</param>
    	/// <returns>A signed integer that indicates the relative values of x and y.</returns>
    	public int Compare(string x, string y)
    	{
    		// Validate parameters
    		if (x == null) throw new ArgumentNullException("x");
    		if (y == null) throw new ArgumentNullException("y");
    		
    		// Test for equality
    		if (x == y)
    			return 0;
    		
    		// Split the different parts of the number
    		string[] xParts = x.Split('.');
    		string[] yParts = y.Split('.');
    		
    		// Compare each parts
    		AlphanumericComparer alphaNumComparer = new AlphanumericComparer();
    		for (int i = 0, n = Math.Max(xParts.Length, yParts.Length); i < n; i++)
    		{
    			// If the part at index i is not in y => x is greater
    			if (i >= yParts.Length)
    				return 1;
    			
    			// If the part at index i is not in x => y is greater
    			if (i >= xParts.Length)
    				return -1;
    			
    			// Compare the two alphanumerical numbers
    			int result = alphaNumComparer.Compare(xParts[i], yParts[i]);
    			if (result != 0)
    			{
    				return result;
    			}
    		}
    		
    		// The two numbers are equal (really??? I thought we tested for equality already!)
    		System.Diagnostics.Debug.Fail("Not supposed to reach this code...");
    		return 0;
    	}
    }
    
    /// <summary>
    /// Compares two alphanumeric strings.
    /// </summary>
    /// <remarks>See http://snipd.net/alphanumericnatural-sorting-in-c-using-icomparer </remarks>
    public class AlphanumericComparer : IComparer<string>
    {
    	/// <summary>
    	/// Compares two alphanumerics and returns a value
    	/// indicating whether one is less than, equal to, or greater than the other.
    	/// </summary>
    	/// <param name="x">The first alphanumeric to compare.</param>
    	/// <param name="y">The second alphanumeric to compare.</param>
    	/// <returns>A signed integer that indicates the relative values of x and y.</returns>
    	public int Compare(string x, string y)
    	{
    		int len1 = x.Length;
    		int len2 = y.Length;
    		int marker1 = 0;
    		int marker2 = 0;
    		
    		// Walk through two the strings with two markers.
    		while (marker1 < len1 && marker2 < len2)
    		{
    			char ch1 = x[marker1];
    			char ch2 = y[marker2];
    			
    			// Some buffers we can build up characters in for each chunk.
    			char[] space1 = new char[len1];
    			int loc1 = 0;
    			char[] space2 = new char[len2];
    			int loc2 = 0;
    			
    			// Walk through all following characters that are digits or
    			// characters in BOTH strings starting at the appropriate marker.
    			// Collect char arrays.
    			do
    			{
    				space1[loc1++] = ch1;
    				marker1++;
    				
    				if (marker1 < len1)
    				{
    					ch1 = x[marker1];
    				}
    				else
    				{
    					break;
    				}
    			} while (char.IsDigit(ch1) == char.IsDigit(space1[0]));
    			
    			do
    			{
    				space2[loc2++] = ch2;
    				marker2++;
    				
    				if (marker2 < len2)
    				{
    					ch2 = y[marker2];
    				}
    				else
    				{
    					break;
    				}
    			} while (char.IsDigit(ch2) == char.IsDigit(space2[0]));
    			
    			// If we have collected numbers, compare them numerically.
    			// Otherwise, if we have strings, compare them alphabetically.
    			string str1 = new string(space1);
    			string str2 = new string(space2);
    			
    			int result;
    			
    			if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
    			{
    				int thisNumericChunk = int.Parse(str1);
    				int thatNumericChunk = int.Parse(str2);
    				result = thisNumericChunk.CompareTo(thatNumericChunk);
    			}
    			else
    			{
    				result = str1.CompareTo(str2);
    			}
    			
    			if (result != 0)
    			{
    				return result;
    			}
    		}
    		return len1 - len2;
    	}
    }
