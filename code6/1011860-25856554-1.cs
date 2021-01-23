	class MyController : ApiController
	{
		private IStrategyFactory _factory;
	
		public MyController(IStrategyFactory factory)
		{
			_factory = factory;
		}
		
		public HttpResponseMessage Get(int value)
		{
			// here we don't care what exact strategy is used, this is good!
			var strategy = _factory.Create(value);
			
			var newValue = strategy.Calculate();
			
			return new HttpResponseMessage(newValue);
		}
	}
