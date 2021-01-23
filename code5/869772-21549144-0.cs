	class B<T> where T : A, I2
	{
		public B(T parameter)
		{
			this.Property = parameter;
		}
		
		public T Property { get; private set; }
	}
