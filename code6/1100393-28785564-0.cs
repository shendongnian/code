	void Main()
	{
		var c = new C();
		c.GetAnotherObject(new BImpl<string, int>());
	}
	
	public class BImpl<T, V> : A<T, V>.B
	{
		
	}
	
	public abstract class A<T, V>
	{
		public abstract int GetObject(T t, V v);
		public abstract int GetAnotherObject(B b);
		public abstract class B{}
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
		return 15;
	}
	}
