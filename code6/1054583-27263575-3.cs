    class TestViewModel : INotifyPropertyChanged
    {
    	private int _selected;
    	public int Selected
    	{
    		get { return _selected; }
    		set
    		{
    			_selected = value;
    			OnPropertyChanged("Selected");
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void OnPropertyChanged(string property)
    	{
    		MessageBox.Show(string.Format("Selected index = {0}", Selected));
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(property));
    		}
    	}
    }
