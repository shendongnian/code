    List<List<int>> cols = new List<List<int>>();
    cols.Add(new List<int>() { 1 });
    cols.Add(new List<int>() { 2,3,4 });
    cols.Add(new List<int>() { 5,6,7 });
    
    int[][] result = new int[100][];
    
    for (int i = 0; i < cols.Count; i++)
    {
    	for (int j = 0; j < cols[i].Count; j++)
    	{
    		if (result[j] == null)
    		{
    			result[j] = new int[100];                        
    		}
    		if (cols[i].Count < j)
    		{
    			result[j][i] = 0;
    		} else
    		{
    		 result[j][i] = cols[i][j];
    		}
    	}
    }
