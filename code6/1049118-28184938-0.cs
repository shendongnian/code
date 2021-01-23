	public struct Token : IDictionary<string, Token>
	{
		/* IDictionary<string, Token> implementation is here */
	}
	public static class Test
	{
		//[MethodImpl(MethodImplOptions.NoOptimization)]
		public static void Method()
		{
			var dict = new Dictionary<string, Token> { { "qwe", new Token() } };
			var arr = dict.ToArray(); // XXX		
		}
	}
