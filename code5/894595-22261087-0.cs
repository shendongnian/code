	public class Printer
	{
		public int Value { get; set; }
		
		public Printer(int x)
		{
			Value = x;
		}
		
		public void Print()
		{
			Console.WriteLine(Value);
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var printer = new Printer(0);
			
			printer.Print();	
			printer.Value++;		
			printer.Print();
		}
	}
