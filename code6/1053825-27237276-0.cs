    private String[] validValues =
        {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
    public String Value
    {
        get { return _value; }
        set 
		{ 
			if (validValues.Contains(value))
				_value = value; 
			else
				throw new InvalidOperationException(); //or whatever you like
		}
    }
