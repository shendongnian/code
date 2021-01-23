    public class MyLoggingClass
    {
    	private readonly ILoggerFactory _loggerFactorty;
    
    	public MyLoggingClass(ILoggerFactory factory)
    	{
    		_loggerFactorty = factory;
    
    		var fileLogger = _loggerFactorty.Create("fileLogger");
    		var consoleLogger = _loggerFactorty.Create("consoleLogger");
    	}
    }
    
    
    public class LoggerFactory : ILoggerFactory
    {
    	public ILogger Create(string key)
    	{
    		return kernel.Resolve<ILogger>(key);
    	}
    }
