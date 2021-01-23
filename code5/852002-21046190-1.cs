	public static IEnumerable<int[]> EnumerateIndices(int[] values, int length)
	{
		int[] result = new int[length];	
		int size = (int)(Math.Pow(values.Length, length));
		for(int i = 0; i < size; ++i)
		{
			int tmp = i;
			for(int j = length - 1; j >= 0; --j)
			{
				result[j] = values[tmp % values.Length];
				tmp /= values.Length;				
			}
			
			yield return result;
		}		
	}
	
	public static int Sum(int[] values)
	{
		// Just a helper method - if you can use LINQ replace by values.Sum()
		int result = 0, size = values.Length;		
		for(int i = 0; i < size; ++i)
		{
			result += values[i];
		}
		return result;
	}
	
	public static string Join(string separator, int[] values)
	{
		// Just a helper method, if you can use LINQ replace by sth like string.Join(separator, values.ToArray<string>())
		string[] stringValues = new string[values.Length];	
		int size = values.Length;
		for(int i = 0; i < size; ++i)
		{
			stringValues[i] = values[i].ToString();	
		}
		return string.Join(separator, stringValues);
	}
	
	public static void Sum42()
	{
   		int[] prefix = { 0, 0, 3, 8, 8, 15};
 		int[] suffix = { 0, 3, 2, 7, 7, 9, 12, 15 };
		
		IEnumerable<int[]> prefixes = EnumerateIndices(prefix, 3);
		IEnumerable<int[]> suffixes = EnumerateIndices(suffix, 3);
		foreach(int[] p in prefixes) {
			foreach(int[] s in suffixes) {
				if(Sum(p) + Sum(s) == 42)
				{
					System.Console.WriteLine("{0} + {1} = 42", Join(" + ", p), Join(" + ", s));	
				}
			}
		}
	}
