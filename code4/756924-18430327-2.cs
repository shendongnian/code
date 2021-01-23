    public IEnumerable<IEnumerable<int>> NAryCartesianProduct(int upper, int times){
    	if (times == 0)
    		return Enumerable.Empty<IEnumerable<int>>();
    	
    	var nums = Enumerable.Range(1, upper);			
    	IEnumerable<IEnumerable<int>> products = nums.Select(i => new[]{i});
    	
    	for (int i = 1; i < times; i++)
    	{
    		products = from p in products
    		           from n in nums
    				   select p.Concat(new [] {n});								   		
    	}		
    	
    	return products;
    }
