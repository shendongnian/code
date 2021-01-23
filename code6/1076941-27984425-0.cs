	private Foo()
	{
		// Do only synchronous initialization here
	}
	public static async Task<Foo> CreateAsync()
	{
		var foo = new Foo();
		await foo.IsLoginOk();
		return foo;
	}
