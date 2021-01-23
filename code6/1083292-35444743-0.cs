    public class SomeVM
	{
		public SomeSettings DSettings { get; set; } // named this way it will work
		public SomeSettings Settings { get; set; } // property named 'Settings' won't bind!
		public bool ResetToDefault { get; set; }
	}
