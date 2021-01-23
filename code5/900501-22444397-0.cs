	public static bool IsSorted(int[] array, int n)
	{
		return
			array
				.Skip(1)
				.Zip(array, (a1, a0) => a1 - a0)
				.All(a => a >= 0);  
	}
