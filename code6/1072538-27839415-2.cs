	struct MyMutableStruct
	{
		private int _value;
		public MyMutableStruct(int value)
		{
			_value = value;
		}
		public int Value { get { return _value; } set { _value = value; } }
	}
	var third = new MyMutableStruct(1);
	var fourth = third;
	// Set a new value.
	fourth.Value = 2;
	Console.WriteLine(third.Value);		// Still prints 1
	Console.WriteLine(fourth.Value);    // Prints 2
