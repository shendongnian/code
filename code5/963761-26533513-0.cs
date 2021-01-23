    public class OwinLoggerFactory : ILoggerFactory
	{
		private readonly ILoggerFactory _baseLoggerFactory;
		public OwinLoggerFactory()
		{
			_baseLoggerFactory=new DiagnosticsLoggerFactory();
		}
		public ILogger Create(string name)
		{
			//create your own OwinLogger class that implements 'ILogger'
            // inside your own OwinLogger class, you may then hook up to any logging Fx you like.
		}
	}
