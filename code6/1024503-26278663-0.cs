	class A
	{
		public B b;
		
		~A()
		{
			Console.WriteLine("COLLECTED A!");
		}
	}
	
	class B
	{
		public A a;
		
		~B()
		{
			Console.WriteLine("COLLECTED B!");
		}
	}
