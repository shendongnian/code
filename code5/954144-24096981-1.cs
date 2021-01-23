    public class PriceModel : INotifyPropertyChanged
    {
    	private double _askPrice;
    	private double _offerPrice;
    	private string _pair;
    
    	public PriceModel(string pair)
    	{
    		_pair = pair;
    	}
    
    	public string Pair
    	{
    		get { return _pair; }
    	}
    
    	public double AskPrice
    	{
    		get { return _askPrice; }
    		set
    		{
    			_askPrice = value;
    			OnPropertyChanged("AskPrice");
    		}
    	}
    
    	public double OfferPrice
    	{
    		get { return _offerPrice; }
    		set
    		{
    			_offerPrice = value;
    			OnPropertyChanged("OfferPrice");
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
