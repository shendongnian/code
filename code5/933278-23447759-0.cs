    public class People : INotifyPropertyChanged
    {
    	public int PersonID { get; set; }
    
    	private string _fullName;
    	public string FullName
    	{
    		get { return _fullName; }
    		set { _fullName = value; OnPropertyChanged("FullName"); }
    	}
    
    	private bool _Status;
    	public bool Status
    	{
    		get { return _Status; }
    		set { _Status = value; OnPropertyChanged("Status"); }
    	}
    
    	private SolidColorBrush _statusColor;
    	public SolidColorBrush StatusColor
    	{
    		get { return _statusColor; }
    		set { _statusColor = value; OnPropertyChanged("StatusColor"); }
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	private void OnPropertyChanged(string name)
    	{
    		if (PropertyChanged != null)
    			PropertyChanged(this, new PropertyChangedEventArgs(name));
    	}
    }
