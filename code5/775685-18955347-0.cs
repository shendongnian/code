    struct Test
	{
		public Int32 Number { get; set; }
		public override string ToString()
		{
			return this.Number.ToString();
		}
	}
	class Program
	{
		static void Main( string[] args )
		{
			Object test = new Test();
			dynamic proxy = test;
			proxy.Number = 1;
			Console.WriteLine( test );
			Console.ReadLine();
		}
	}
