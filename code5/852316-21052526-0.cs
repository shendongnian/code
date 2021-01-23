    class MyClass
	{
		private IEnumerator<string> _next = Next();
		
		public MyClass()
		{
			this._next.MoveNext();
		}
	
		public string MyName
		{
			get
			{
				var n = this._next.Current;
				this._next.MoveNext();
				return n;
			}
		}
				
				
		public static IEnumerator<string> Next()
		{
			yield return "foo";
			yield return "bar";
		}
	}
