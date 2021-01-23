    public static class Calculator<T>
    {
        private static readonly Func<T, T, T> add;
    
        static Calculator() 
        {
            var param1 = Expression.Parameter(typeof(T));
            var param2 = Expression.Parameter(typeof(T));
            var addLambda = Expression.Lambda<Func<T, T, T>>(
    			Expression.Add(param1, param2),
    			param1, param2
    		);
    		add = addLambda.Compile();
        }
    	
        // invoke as Calculator<T>.Add(a, b)
    	public static T Add(T a, T b)
    	{	
    		return add(a, b);
    	}
    }
