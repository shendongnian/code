    public static class ArrayListExtensions
    {
    	/// <summary>
    	/// Removes all the elements equal to <paramref name="sample"/>.
    	/// </summary>
    	/// <param name="list">List to remove from.</param>
    	/// <param name="sample">Element to remove.</param>
        /// <returns>Returns the number of removed elements.</returns>
    	public static int RemoveAll(this ArrayList list, object sample)
    	{
            if (list == null)
                throw new ArgumentNullException("list");
    		var n = list.Count;
    		var nextOut = 0;
    		var nextIn = 0;
    		for (; nextIn < n && nextIn == nextOut; nextIn++)
    		{
    			var token = list[nextIn];
    			if (!Equals(token, sample))
    			{
    				nextOut++;
    			}
    		}
    		
    		for (; nextIn < n; nextIn++)
    		{
    			var token = list[nextIn];
    			if (!Equals(token, sample))
    			{
    				list[nextOut] = token;
    				nextOut ++;
    			}
    		}
    		
    		if (nextOut < list.Count)
    		{
    			var toRemove = list.Count - nextOut;
    			list.RemoveRange(nextOut, toRemove);
    			return toRemove;
    		}
    		return 0;
    	}
    }
