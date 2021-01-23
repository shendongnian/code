	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Comparing different value (and reference) types to zero:");
			Console.WriteLine();
			Console.WriteLine("Checking int '9' : {0}", IsNegative(9));
			Console.WriteLine("Checking int '-9': {0}", IsNegative(-9));
			Console.WriteLine("Checking int '0' : {0}", IsNegative(0));
			Console.WriteLine();
			Console.WriteLine("Checking decimal '9' : {0}", IsNegative(9m));
			Console.WriteLine("Checking decimal '-9': {0}", IsNegative(-9m));
			Console.WriteLine("Checking decimal '0' : {0}", IsNegative(0m));
			Console.WriteLine();
			Console.WriteLine("Checking float '9'  : {0}", IsNegative(9f));
			Console.WriteLine("Checking float '-9' : {0}", IsNegative(-9f));
			Console.WriteLine("Checking float '0'  : {0}", IsNegative(0f));
			Console.WriteLine();
			Console.WriteLine("Checking long '9'  : {0}", IsNegative(9L));
			Console.WriteLine("Checking long '-9' : {0}", IsNegative(-9L));
			Console.WriteLine("Checking long '0'  : {0}", IsNegative(0L));
			Console.WriteLine();
			Console.WriteLine("Checking string '9'   : {0}", IsNegative("9"));
			Console.WriteLine("Checking string '-9'  : {0}", IsNegative("-9"));
			Console.WriteLine("Checking string empty : {0}", IsNegative(string.Empty));
			Console.WriteLine("Checking string null  : {0}", IsNegative((string)null));
			Console.WriteLine();
			Console.WriteLine("Checking DateTime.Now '{0}' : {1}", DateTime.Now, IsNegative(DateTime.Now));
			Console.WriteLine("Checking DateTime.Max '{0}' : {1}", DateTime.MaxValue, IsNegative(DateTime.MaxValue));
			Console.WriteLine("Checking DateTime.Min '{0}' : {1}", DateTime.MinValue, IsNegative(DateTime.MinValue));
			Console.WriteLine();
			Console.WriteLine("Checking positive MyStruct : {0}", IsNegative(new MyStruct() { MainValue = 9 }));
			Console.WriteLine("Checking negative MyStruct : {0}", IsNegative(new MyStruct() { MainValue = -9 }));
			Console.WriteLine("Checking zero MyStruct     : {0}", IsNegative(new MyStruct() { MainValue = 0 }));
			Console.WriteLine();
			Console.ReadKey();
		}
		private static bool IsNegative<T>(T value)
		{
			return Comparer<T>.Default.Compare(value, default(T)) < 0;
		}
		private struct MyStruct : IComparable<MyStruct>, IComparer<MyStruct>
		{
			public int MainValue;
			public int CompareTo(MyStruct other)
			{
				return MainValue - other.MainValue;
			}
			public int Compare(MyStruct x, MyStruct y)
			{
				return x.MainValue - y.MainValue;
			}
		}
	}
