		public static IEnumerable<System.Numerics.BigInteger> Fibonacci()
		{
			System.Numerics.BigInteger current = 0, next = 1;
			while (true) 
			{
				yield return current;
				next = current + next;
				current = next - current; // isn't mutation ugly to read?
			}
		}
