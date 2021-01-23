    List<List<int>> cols = new List<List<int>>();
    cols.Add(new List<int>() { 1, 2, 3, 4, 5, 6 });
    cols.Add(new List<int>() { 9, 8, 7, 6, 4, 4 });
    
    int[][] result = new int[100][];
    
    for (int i = 0; i < cols.Count; i++ )
    {
    	for (int j = 0; j < cols[i].Count; j++ )
    	{
    		if (result[j] == null)
    		{
    			result[j] = new int[100];
    		}
    		result[j][i] = cols[i][j];
    	}
    }
