    public class MyControlViewModel
    {
    	public event EventHandler OnTextboxOrComboBoxChanged;
    	
    	private string _myTextBoxValue;
    	public string MyTextBoxValue
    	{
    		get { return _myTextBoxValue; }
    		set 
    		{ 
    			_myTextBoxValue = value; 
    			OnPropertyChanged("MyTextBoxValue");
    			if(OnTextboxOrComboBoxChanged != null)
    				OnTextboxOrComboBoxChanged(); // trigger the event
    		}
    	}
    	
    	// other codes here
    }
