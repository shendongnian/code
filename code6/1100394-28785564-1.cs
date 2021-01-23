	void Main()
	{
		var c = new C();
		var result = c.GetAnotherObject(new BImpl<string, int>());
	}
	
	public class BImpl<T, V> : A<T, V>.B
	{
		public override int BM()
		{
			return 1;
		}
	}
    // Or you can supply type arguments right here
	//public class BImpl : A<string, int>.B
	//{
	//	public override int BM()
	//	{
	//		return 1;
	//	}
	//}
	
	public abstract class A<T, V>
	{
		public abstract int GetObject(T t, V v);
		public abstract int GetAnotherObject(B b);
		public abstract class B
		{
			public abstract int BM();
		}
	}
	
	public class C : A<string, int>
	{
		public C()
		{
		
		}
		
		public override int GetObject(string abc, int def)
		{
			return 10;
		}
		
		public override int GetAnotherObject(B b)
		{
			return b.BM();
		}
	}
