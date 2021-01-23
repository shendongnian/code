    public class ViewModel
    {
    	private ObservableDictionary<int, string> _firstDictionary;
    
    	public ViewModel()
    	{
    		_firstDictionary = new ObservableDictionary<int, string>()
    				{
    					new KeyValuePair<int, string>(1, "A"),
    					new KeyValuePair<int, string>(2, "B"),
    					new KeyValuePair<int, string>(3, "C")
    				};
    	}
    
    	public ObservableDictionary<int, string> FirstDictionary
    	{
    		get { return _firstDictionary; }
    		set { _firstDictionary = value; }
    	}
    }
