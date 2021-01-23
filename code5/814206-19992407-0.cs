    void Main()
    {
	Expression<Func<object>> f = () => new Potato();
	Helper.MyProduce(f);
    }
    public class Tomato 
    {}
    public class Potato
    {}
    public static class Helper
    {
    public static void MyProduce(Expression<Func<object>> expression)
	{
		var func = expression.Compile();
		var result = func();
		
		if(result is Tomato)
			Console.Write("Tomato");
		else if (result is Potato)
			Console.Write("Potato");
		else
			Console.Write("Unknown");
	}
    }
