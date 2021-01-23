	public interface IInterface1
	{
	    string Bar1{ get; set; }
	    string Bar2{ get; set; }
	}
	public interface IInterface2<T> where T : IInterface1
	{
	    T Foo{ get; set; }
	}
	
	public class Class1<T> : IInterface2<T> where T : IInterface1
	{
	    public T Foo { get; set; }
	}
