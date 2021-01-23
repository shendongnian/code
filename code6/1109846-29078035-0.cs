	class Program
	{
		static void Main(string[] args)
		{
			object test = new Test { DemoProperty = "Some", DemoListProperty = new List<int> { 1, 2, 3, 4 } };
			Type type = typeof(Test);
			foreach (var pi in type.GetProperties())
			{
				if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
				{
					IEnumerable objects = pi.GetGetMethod().Invoke(test,null) as IEnumerable;
					foreach (var o in objects)
					{
						Console.WriteLine(o); //may want to do recursion here and iterate over these properties too
					}
				}
			}
		}
	}
	class Test
	{
		public string DemoProperty { get; set; }
		public List<int> DemoListProperty { get; set; }
	}
