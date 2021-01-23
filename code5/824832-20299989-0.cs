	public class X : OuterClass<X>.InnerClass
	{
	}
	public class OuterClass<T> where T : OuterClass<T>.InnerClass, new()
	{
		public T GetInnerInstance()
		{
			return new T();
		}
		public class InnerClass
		{
			public InnerClass()
			{
			}
		}
	}
	public class Foo
	{
		OuterClass<X> _instance; // yup
	}
