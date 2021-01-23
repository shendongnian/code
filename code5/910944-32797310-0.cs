    static string[][] GetStringArray(Object rangeValues)
    {
    	string[][] stringArray = null;
    
    	Array array = rangeValues as Array;
    	if (null != array)
    	{
    		int rank = array.Rank;
    		if (rank > 1)
    		{
    			int rowCount = array.GetLength(0);
    			int columnCount = array.GetUpperBound(1);
    
    			stringArray = new string[rowCount][];
    
    			for (int index = 0; index < rowCount; index++)
    			{
    				stringArray[index] = new string[columnCount-1];
    
    				for (int index2 = 0; index2 < columnCount; index2++)
    				{
    					Object obj = array.GetValue(index + 1, index2 + 1);
    					if (null != obj)
    					{
    						string value = obj.ToString();
    
    						stringArray[index][index2] = value;
    					}
    				}
    			}
    		}
    	}
    
    	return stringArray;
    }
