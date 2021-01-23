    class Bar
	{
		private Foo foo;
		
		public Bar(Foo foo)
		{ 
			_foo = foo;
		}
			
		public void MethodCaller()
		{
			_foo.MethodToCall();
		}
	}
