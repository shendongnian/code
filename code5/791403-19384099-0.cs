    public static IEnumerable<float> SmoothGaps(this IEnumerable<float?> source)
    {
        int numberOfNulls = 0;
        foreach(var item in source)
    	{
    	    if(item == null)
    		{
    		    ++numberOfNulls;
    		}
    		else
    		{
    		    if(numberOfNulls != 0)
    			{
    			    for(int i=0; i <= numberOfNulls; ++i)
    				    yield return item.Value / (numberOfNulls + 1);
    			}
    			else
    			    yield return item.Value;
    		    numberOfNulls = 0;
    		}
    	}
    }
