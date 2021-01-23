    public class GroupClass : INotifyPropertyChanged
    {
    	private bool _isActive;
    	private string _content;
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	[NotifyPropertyChangedInvocator]
    	protected virtual bool Set<T>(ref T field, T newVal, [CallerMemberName] string propertyName = null)
    	{
    		if (Equals(field, newVal)) return false;
    		field = newVal;
            if(PropertyChanged!=null)
    		PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    		return true;
    	}
    
    
    	public string Content
    	{
    		get { return _content; }
    		set { Set(ref _content, value); }
    	}
    
    	public bool IsActive
    	{
    		get { return _isActive; }
    		set
    		{
    			if(Set(ref _isActive, value))
    			Content = _isActive ? "/Assets/Images/Active.png" : "/Assets/Images/Inactive.png";
    		}
    	}
    }
