    public class MultiResImageChooser : INotifyPropertyChanged
    {
	    public event NotifyPropertyChangedArgs PropertyChanged;
    	...
	
	    public ImageSource BestResolutionImage
	    {
	    	get
	    	{
	    		return _bestResolutionImage;
	    	}
	    	set
	    	{
	    		if(value != _bestResolutionImage)
	    		{
	    			_bestResolutionImage = value;
	    			OnPropertyChanged("BestResolutionImage");
	    		}
	    	}
	    }
    	protected virtual void OnPropertyChanged(string property)
    	{
    		if(null != PropertyChanged)
    		{
    			PropertyChanged(this, new NotifyPropertyChangedEventArgs(property));
    		}
    	}
    }
