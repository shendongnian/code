    public class SelectionItem<T> : INotifyPropertyChanged
    {
    	private AppliesTo _appliesTo;
    	public AppliesTo AppliesTo
    	{
    		get { return _appliesTo; }
    		set
    		{
    			_appliesTo = value;
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs("AppliesTo"));
    		}
    	}
    }
