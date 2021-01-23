    public class Stat : INotifyPropertyChanged
    {
        private int _your_property;
	    public int your_property {
		    get { return _your_property; }
		    set {
			    _your_property = value;
			    NotifyPropertyChanged("your_property");
		    }
	    }
	    
	    public event PropertyChangedEventHandler PropertyChanged;
	    private void NotifyPropertyChanged(string propertyName)
	    {
		    PropertyChangedEventHandler handler = PropertyChanged;
		    if (null != handler) {
			    handler(this, new PropertyChangedEventArgs(propertyName));
		    }
	    }
    }
