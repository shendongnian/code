    public static long Factorial(int x)
    {
    	long result = 1;
    	int right = 0;
    	int nr = x;
    	bool done = false;
    
    	var tasks = new List<Task>();
    
    	for (int i = 0; i < nr; i += (nr / 4))
    	{
    		int step = i;
    		tasks.Add(Task.Run(() =>
    			{
    				right = (step + nr / 4) > nr ? nr : (step + nr / 4);
    				long chunkResult = ChunkFactorial(step + 1, right);
    
    				lock (_locker)
    				{
    					result *= chunkResult;
    				}
    			}));
    	}
    
    	Task.WaitAll(tasks.ToArray());
    
    	return result;
    }
