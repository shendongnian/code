    public class MyViewModel : INotifyPropertyChanged
    {
    	private ObservableCollection<Banjo> _banjoList;
    	public ObservableCollection<Banjo> BanjoList
    	{
    		get { return _banjoList; }
    		set
    		{
    			_banjoList = value;
    			RaisePropertyChanged("BanjoList");
    		}
    	}
    
    	public MyViewModel()
    	{
    		// populate list
    	}
    }
