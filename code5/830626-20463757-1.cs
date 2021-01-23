	class StringAtLocation : IPositionValue<string>
	{
		public float X { get; set; }
		public float Y { get; set; }
		public string Value { get; set; }
	}
	static void Main()
	{
		StringAtLocation foo = new StringAtLocation { X = 0, Y = 0, Value = "foo" };
		// All of the following are valid because of interface inheritence:
		IHasPosition ihp = foo;
		IHasValue<string> ihv = foo;
		IPositionValue<string> ipv = foo;		
	}
