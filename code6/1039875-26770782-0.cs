    public class DatabaseStrategyFactory
    {
    	private static DatabaseStrategyFactory _instance;
    	private Dictionary<string, Strategy> _collection;
    
    	private DatabaseStrategyFactory()
    	{
    	
    	}
    	
    	// singleton pattern
    	public static DatabaseStrategyFactory Instance { get { return _instance ?? (_instance = new DatabaseStrategyFactory()); }}
    	
    	public static Initialize()
    	{
    		// load all strategies either by creating instances or storing the type
    		if(_collection == null)
    		{
    			_collection = new Dictionary<string, Strategy>();
    			_collection.Add(*string key either by class name/enum or whatever you want*, instance or type);
    		}
    	}
    	
    	public Strategy GetStrategy(string name)
    	{
    		if(_collection == null)
    			throw new Exception();
    		Strategy strategy = null;
    		_collection.TryGetValue(name, out strategy);
    		return strategy;
    	}
    }
