    public static class RandomExtensions
    {
    	class NormalizedPair
    	{
    		public int Value {get;set;}
    		public PairStatus Status {get;set;}
    	
    		public NormalizedPair(int value){
    			Value = value;
    		}
    		
    		public enum PairStatus {
    			Free,
    			NotFree
    		}
    	}
    	
    	private static Random _internalRandom = new Random();
    	
    	public static int Next(this Random random, 
    		int minInclusive, 
    		int maxExclusive, 
    		IList<int> values)
    	{
    		var elements = maxExclusive - minInclusive;
    		var normalizedArr  = new NormalizedPair[elements];
    		
    		var normalizedMinInclusive = 0;
    		var normalizedMaxExclusive = maxExclusive - minInclusive;
    		var normalizedValues = values
    				.Select(x => x - minInclusive)
    				.ToList();
    		
    		for(var j = 0; j < elements; j++)
    		{
    			normalizedArr[j] = new NormalizedPair(j){
    				Status = NormalizedPair.PairStatus.Free
    			};
    		}
    		
    		foreach(var val in normalizedValues)
    			normalizedArr[val].Status = NormalizedPair.PairStatus.NotFree;
    
    		return  normalizedArr
    					.Where(y => y.Status == NormalizedPair.PairStatus.Free) // take only free elements
    					.OrderBy(y => _internalRandom.Next()) // shuffle the free elements
    					.Select(y => y.Value + minInclusive) // project correct values
    					.First(); // pick first.
    	}
    }
