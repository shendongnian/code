    public abstract class ViewModelBase : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void OnPropertyChanged(string propertyName)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    
    	private int _caretIndex;
    
    	public int CaretIndex
    	{
    		get { return _caretIndex; }
    		set
    		{
    			_caretIndex = value;
    			OnPropertyChanged("CaretIndex");
    			OnCaretIndexChanged();
    		}
    	}
    
    	private string _inputValue;
    	public string InputValue
    	{
    		get { return _inputValue; }
    		set
    		{
    			_inputValue = value;
    			OnPropertyChanged("InputValue");
    			OnInputValueChanged();
    		}
    	}
    
    	protected abstract void OnCaretIndexChanged();
    
    	protected abstract void OnInputValueChanged();
    }
