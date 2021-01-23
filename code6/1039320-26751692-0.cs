    class Foo2 : IFoo
    {
        public Task<Bar> CreateBarAsync()
    	{
    		return Task.FromResult<Bar>(SynchronousBarCreator());
    	}
    }
