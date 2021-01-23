public class Foo {
	private readonly Func<IBar> _barFunc;
	public Foo(Func<IBar> barFunc) {
		_barFunc = barFunc;
	}
}
