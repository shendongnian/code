	public HttpResponseMessage Post(IEnumerable<MyModel> models)
	{
		return DoSomething(models);
	}
	public HttpResponseMessage Post(MyModel model)
	{
		return DoSomething(new List<MyModel> { model });
	}
	private HttpResponseMessage DoSomething(IEnumerable<MyModel> models)
	{
		// Do something
	}
