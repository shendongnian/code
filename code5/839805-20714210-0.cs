    public partial class MainPage :  PhoneApplicationPage, INotifyPropertyChanged
    {
    	public MainPage()
    	{
    		InitializeComponent();
    		this.DataContext = this;
    		ButtonsRenderSize = 0.75;
    	}
    	
    	private double _buttonsRenderSize;
    	public double ButtonsRenderSize 
    	{
    		get { return _buttonsRenderSize; }
    		set 
    		{  
    			if(value != _buttonsRenderSize)
    			{
    				_buttonsRenderSize = value;
    				//raise propertychanged event to notify UI's property to update it's value
    				OnPropertyChanged("ButtonsRenderSize");
    			}
    		}
    	}
    	
    	#region INotifyPropertyChanged implementation
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected virtual void OnPropertyChanged(string propertyName)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    	#endregion
    }
