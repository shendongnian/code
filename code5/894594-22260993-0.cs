    public class Printer
    {
    	private readonly Func<int> f;
    	public Printer(Func<int> f)
    	{
    		this.f = f;
    	}
    
    	public void Print()
    	{
    		Console.WriteLine(f());
    	}
    }
    MyPrinter printer = new MyPrinter(() => x);
    printer.Print(); //Expected result is 0
    x++;
    MyPrinter.Print(); //Expected result is 1
