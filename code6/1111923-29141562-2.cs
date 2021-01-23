    public static long Factorial(int x)
    {
    	int nr = x;
    	var tasks = new List<Task<long>>();
    
    	for (int i = 0; i < nr; i += (nr / 4))
    	{
    		int step = i;
    		tasks.Add(Task.Run(() =>
    			{
    				int right = (step + nr / 4) > nr ? nr : (step + nr / 4);
    				return ChunkFactorial(step + 1, right);
    			}));
    	}
    
    	Task.WaitAll(tasks.ToArray());
    
    	return tasks.Select(t => t.Result).Aggregate(((i, next) => i * next));
    }
