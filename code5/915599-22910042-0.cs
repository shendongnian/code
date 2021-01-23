	static void Main()
	{
		var x = Enumerable.Range(0, 1).Sum(a);
	}
	private static int a(int a)
	{
		return Enumerable.Range(0, 1).Sum(b);
	}
	private static int b(int b)
	{
		return Enumerable.Range(0, 1).Sum(c);
	}
	private static int c(int c)
	{
		return Enumerable.Range(0, 1).Sum(d);
	}
	private static int d(int d)
	{
		return Enumerable.Range(0, 1).Sum(e);
	}
	private static int e(int e)
	{
		return Enumerable.Range(0, 1).Sum(f);
	}
	private static int f(int f)
	{
		return Enumerable.Range(0, 1).Count(g);
	}
	private static bool g(int g)
	{
		return true;
	}
