	static bool IsEven(int i)
	{
		return i % 2 == 0;
	}
	static bool IsOdd(int i)
	{
		return i % 2 != 0;
	}
	static int PairCount(int len)
	{
		return len * (len - 1) / 2;
	}
	public static int GetEvenSumCount(int[] A)
	{
		int evensCount = A.Count(IsEven);
		int oddCount = A.Count(IsOdd);
		return PairCount(evensCount) + PairCount(oddCount);
	}
