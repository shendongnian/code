	class A
	{
		public A()
		{
			//this.Display();
		}
		public virtual void Display()
		{
			Console.WriteLine("A");
		}
	}
	class B : A
	{
		public override void Display()
		{
			base.Display();
			Console.WriteLine("B");
		}
	}
	class C
	{
		static void Main(string[] args)
		{
			A a = new B();
			a.Display();
			Console.WriteLine();
			Console.ReadLine();
		}
	}
