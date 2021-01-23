	void Main()
	{
		var fooBar = new FooBar();
		
		fooBar.GetInput();
		fooBar.Calculate();
		fooBar.Display();
	}
	
	public class Foo
	{
		public int FirstNumber { get; set; }
		public int SecondNumber { get; set; }
	
		public void GetInput()
		{
			Console.WriteLine("Please enter the first number");
			this.FirstNumber = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Please enter the second number");
			this.SecondNumber = Convert.ToInt32(Console.ReadLine());
		}
	}
	
	public class Bar : Foo
	{
		public int Result { get; set; }
		public void Calculate()
		{	
			this.Result = FirstNumber + SecondNumber;
		}
		
	}
	
	public class FooBar : Bar 
	{
	
		public void Display()
		{
			Console.WriteLine("{0} + {1} = {2}", this.FirstNumber, this.SecondNumber, this.Result);
		}
	}
