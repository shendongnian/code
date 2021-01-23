	public static class MyClass
	{
		private static T CommonWorkMethod<T>(Func<T> wishMultipleArgsFunc)
		{
			// ... do common preparation
			T returnValue = wishMultipleArgsFunc();
			// ... do common cleanup
			return returnValue;
		}
		
		public static int DoCommonWorkNoParams() => CommonWorkMethod<int>(ProduceIntWithNoParams);
		public static long DoCommonWorkWithLong(long p1) => CommonWorkMethod<long>(() => ProcessOneLong(p1));
		public static string DoCommonWorkWith2Params(int p1, long p2) => CommonWorkMethod<string>(() => ConvertToCollatedString(p1, p2));
		
		private static int ProduceIntWithNoParams() { return 5; }
	}
