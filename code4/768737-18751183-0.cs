	interface I1
	{
	}
	class ClassOfI1 : I1
	{
	}
	interface I2
	{
		I1 ABC { get; set; }
	}
	class ClassOfI2 : I2
	{
		public I1 ABC { get; set; }
	}
