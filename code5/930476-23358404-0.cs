	struct MyStruct
	{
		private int x;
		public MyStruct(int x)
		{
			if (x > 1599)
				this.x = 399;
			else if (x < 1200)
				this.x = 0;
			else
				this.x = x - 1200;
		}
		public int X { get { return x+1200; } }
	}
