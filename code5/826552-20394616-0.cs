		public static async Task<int> M1(int value)
		{
			await Task.Delay(20000);
			return value;
		}
		public static Task<int> M2(int value)
		{
			return Task.Delay(20000).ContinueWith<int>(_=>value);
		}
