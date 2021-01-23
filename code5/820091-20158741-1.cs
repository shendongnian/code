    void Main()
    {
      var dctBloombergStockData = new Dictionary<string, object>
            {
                { "NAME", "IBM" },
                {  "PX_LAST", 181.30f },
                { "SETTLE_DT", "11/25/2013" } // This is Datetime value
            };
    	StockDataResult.FromBloombergData(dctBloombergStockData);
    }
    
    // Define other methods and classes here
    interface IMapper
    {
    	string PropertyName { get; }
    	object Parse(object source);
    }
    
    class Mapper<T, TResult> : IMapper
    {
    	private Func<T, TResult> _parser;
    	public Mapper(string propertyName, Func<T, TResult> parser)
    	{
    		PropertyName = propertyName;
    		_parser = parser;
    	}
    	
    	public string PropertyName { get; private set; }
    	
    	public TResult Parse(T source)
    	{
    		source.Dump();
    		return _parser(source);
    	}
    
    	object IMapper.Parse(object source)
    	{
    		source.Dump();
    		return Parse((T)source);
    	}
    }
    
    public class StockDataResult
    {
    	private static TypeAccessor Accessor = TypeAccessor.Create(typeof(StockDataResult));
    	
    	private static readonly Dictionary<string, IMapper> Mappers = new Dictionary<string, IMapper>(StringComparer.CurrentCultureIgnoreCase){
    	    	{ "NAME", new Mapper<string, string>("Name", a => a) },
    	    	{ "PX_LAST", new Mapper<float, decimal>("LastPrice", a => Convert.ToDecimal(a)) },
    	    	{ "SETTLE_DT", new Mapper<string, DateTime>("SettlementDate", a => DateTime.ParseExact(a, "MM/dd/yyyy", null)) }
    	    };
    	
    	protected StockDataResult()
    	{ }
    	
    	public string Name { get; set; }
    	public float LastPrice { get; set; }
    	public DateTime SettlementDate { get; set; }
    	public decimal EPS { get; set; }
    	
    	public static StockDataResult FromBloombergData(Dictionary<string, object> state)
    	{
    		var result = new StockDataResult();
    		IMapper mapper;
    		foreach (var entry in state)
    		{
    			if(!Mappers.TryGetValue(entry.Key, out mapper))
    			{ continue; }
    			Accessor[result, mapper.PropertyName.Dump()] = mapper.Parse(entry.Value);
    		}
    		return result;
    	}
    }
