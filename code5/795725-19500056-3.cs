    public class FooToBarsConverter : IFooToBarsConverter
	{
		public List<Bar> Convert(Foo foo)
		{
			return new List<Type>
			{
				typeof(Bar.BarA),
				typeof(Bar.BarB)
			}.Select(it => CreateBar(foo, it))
			.ToList();
		}
		public Bar CreateBar<T>(Foo foo)
			where T : Bar
		{
			return CreateBar(foo, typeof(T));
		}
		private Bar CreateBar(Foo foo, Type barType)
		{
			return typeof(Bar).IsAssignableFrom(barType)
				? (Bar)Activator.CreateInstance(barType, foo)
				: null;
		}
	}
	public class Foo
	{
	}
	public abstract class Bar
	{
		private Bar(Foo foo)
		{
		}
		public class BarA : Bar
		{
			public BarA(Foo foo)
				: base(foo)
			{
			}
		}
		public class BarB : Bar
		{
			public BarB(Foo foo)
				: base(foo)
			{
			}
		}
	}
