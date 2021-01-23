    static class LinqExtensions
    {
    	public static T[,] ToRectangularArray<T>(this IEnumerable<IEnumerable<T>> arrays)
    	{
    		// TODO: Validation and special-casing for arrays.Count == 0
            // TODO: Rename "arrays"
            // TODO: Make sure that Count() is used only once,
            // TODO: ElementAt() does not work everywhere, you're better off using ToList() before!
    		int minorLength = arrays.First().Count();
    		T[,] ret = new T[arrays.Count(), minorLength];
    		for (int i = 0; i < arrays.Count(); i++)
    		{
    			var array = arrays.ElementAt(i);
    			if (array.Count() != minorLength)
    			{
    				throw new ArgumentException
    					("All arrays must be the same length");
    			}
    			for (int j = 0; j < minorLength; j++)
    			{
    				ret[i, j] = array.ElementAt(j);
    			}
    		}
    		return ret;
    	}
    }
    
    void Main()
    {
    	var wat = new[]{new[]{2, 4, 5}, new[]{6, 7, 8}}.ToRectangularArray();
    	wat.Dump();
    }
