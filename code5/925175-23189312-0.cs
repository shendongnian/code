    public class Common : INotifyPropertyChanged
    {
    	private static Common _instance = null;
    
    	protected Common()
    	{
    	}
    
    	public static Common GetInstance()
    	{
    		if (_instance == null)
    			_instance = new Common();
    
    		return _instance;
    	}
    
    	private string _title;
    	public string Title
    	{
    		get { return _title; }
    		set
    		{
    			if (_title == value)
    				return;
    			_title = value;
    			OnPropertyChanged("Title");
    		}
    	}
    
    	public void Load()
    	{
    	}
    
    	public virtual void OnPropertyChanged(string propertyName)
    	{
    		PropertyChangedEventArgs ea = new PropertyChangedEventArgs(propertyName);
    		if (PropertyChanged != null)
    			PropertyChanged(this, ea);
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    }
