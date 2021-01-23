	class A
	{
		protected int first;
		protected int second;
		protected int add;
		public void input()
		{
			Console.WriteLine("Please enter the first number: ");
			first = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Please enter the second number: ");
			second = Convert.ToInt32(Console.ReadLine());
		}
		public void sum()
		{
			add = first + second;
		}
	}
	class B : A 
	{
		public void display()
		{
			Console.WriteLine("You entered {0} and {1} the sum of two numbers is {3}",first,second,add); // here you go
		}
	}
