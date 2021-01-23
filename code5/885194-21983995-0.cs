    public class User : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    	private string _name;
    	private int _age;
    
    	public string Name
    	{
    		get { return _name; }
    		set { _name = value; OnPropertyChanged(); }
    	}
    
    	public int Age
    	{
    		get { return _age; }
    		set { _age = value; OnPropertyChanged(); }
    	}
    
    	[NotifyPropertyChangedInvocator]
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
