	public class Base<T, U>
	{
	
	}
	
	public class Derived<T> : Base<T, int>
	{
	
	}
	
	Derived<long> l = new Derived<long>();
