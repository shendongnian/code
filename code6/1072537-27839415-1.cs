	struct MyImmutableStruct
	{
		private readonly int _value;
		public MyImmutableStruct(int value)
		{
			_value = value;
		}
		public int Value { get { return _value; } }
	}
