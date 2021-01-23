		public static IEnumerable<System.Numerics.BigInteger> Fibonacci()
		{
			System.Numerics.BigInteger b1 = 0, b2 = 1;
			while (true) 
			{
				yield return b1;
				b2 = b1 + b2;
				b1 = b2 - b1;
			}
		}
