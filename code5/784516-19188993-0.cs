	private string _myPropertyText;
	public string MyProperty
	{		
		get { return _myPropertyText; }
		set { 
			 if(_myPropertyText != value) 
			 {
				_myPropertyText = value; 
				OnPropertyChanged("MyPropertyTextBox");
			 }
			}
	}
