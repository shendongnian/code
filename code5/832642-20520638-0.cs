    public abstract class Notifiable : INotifyPropertyChanged
    {
        protected PropertyChangedEventHandler hookup;
    
    	public Notifiable()
    	{
    		hookup = (sender, arg) => OnPropertyChanged(arg.PropertyName);
    	}
        ...
    }
        
