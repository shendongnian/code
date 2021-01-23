	public class MyViewModel : IDataErrorInfo
	{
	    public string MyProperty
	    {
	        get { return _myProperty; }
	        set
	        {
	            if (_myProperty != value)
	            {
	                _myProperty = value;
	                NotifyPropertyChanged(() => MyProperty);
					if (string.IsNullOrEmpty(this["MyProperty"]))
					{
	                	SaveSettings();
					}
	            }
	        }
	    }
	
	    public string Error
	    {
	        get { return string.Empty; }
	    }
	
	    public string this[string columnName]
	    {
	        get
	        {
	            if (columnName == "MyProperty")
	                return "ERROR";
	            return string.Empty;
	        }
	    }
	}
