	public class Employee1
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public MyEnum1 TestEnum { get; set; }
	}
	public enum MyEnum1
	{
		red = 1,
		yellow = 2
	}
	public class Employee2
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public MyEnum2 TestEnum { get; set; }
	}
	public enum MyEnum2
	{
		red = 1,
		yellow = 2
	}
	public class Enum1to2TypeConverter : ITypeConverter<MyEnum1, MyEnum2>
	{
		public MyEnum2 Convert(ResolutionContext context)
		{
			return (MyEnum2)(context.SourceValue);
		}
	}
	public class Test
	{
		public void Example()
		{
			Mapper.CreateMap<MyEnum1, MyEnum2>().ConvertUsing(new Enum1to2TypeConverter());
			Mapper.CreateMap<Employee1, Employee2>();
			Mapper.AssertConfigurationIsValid();
			var source = new Employee1
			{
				Id = 1,
				Name = "Employee1-Name",
				TestEnum = MyEnum1.yellow
			};
			Employee2 result = Mapper.Map<Employee1, Employee2>(source);
            //Check content of result here!
		}
	}
	class Program
	{
		private static void Main(string[] args)
		{
			(new Test()).Example();
		}
	}
