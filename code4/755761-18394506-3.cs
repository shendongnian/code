    public static class Extensions{
    	// assumes that supply a Func<T, int> that will return an int to compare by
    	public static Tuple<T, T> MaxMin<T>(this IEnumerable<T> sequence, Func<T, int> propertyAccessor){
    		int min = int.MaxValue;
    		int max = int.MinValue;
    		
    		T maxItem = default(T);
    		T minItem = default(T);
    		foreach (var i in sequence)
    		{
    			var propertyValue = propertyAccessor(i);
    			if (propertyValue > max){
    				max = propertyValue;
    				maxItem = i;
    			}
    			
    			if (propertyValue < min){
    				min = propertyValue;
    				minItem = i;
    			}						
    		}
    		
    		return Tuple.Create(maxItem, minItem);
    }
    // max will be stored in first, min in second
    var maxMin = word.MaxMin(s => s.Length);
