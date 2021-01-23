    public static class Math
    {
        // Sequential execution
    	public static System.Numerics.BigInteger Factorial(System.Numerics.BigInteger x)
    	{
    		System.Numerics.BigInteger res = x;
    		x--;
    		while (x > 1)
    		{
    			res *= x;
    			x--;
    		}
    		return res;
    	}
    	
    	public static System.Numerics.BigInteger FactorialPar(System.Numerics.BigInteger x)
    	{
    		return NextBigInt().TakeWhile(i => i <= x).AsParallel().Aggregate((acc, item) => acc * item);
    	}
    	
    	public static IEnumerable<System.Numerics.BigInteger> NextBigInt()
    	{
    		System.Numerics.BigInteger x = 0;
    		while(true)
    		{
    			yield return (++x);
    		}
    	}
    }
