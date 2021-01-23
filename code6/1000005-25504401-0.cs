    public int Age
    {
        get { return _age; }
        set
        {
            int oldVal = _age;
            _age = value;
            if(Validate("Age") == null)
            {
               // Do whatever you want
               OnPropertyChanged("Age");
            }
            else
            {
                // You can rollback value or not, it wouldnt matter...
                // PropertyChanged will not be fired!!!
                _age = oldVal;
            }
        }
    }
    public string this[string columnName]
    {
        get
        {
           return Validate(columnName);
        }
    }
    public string Validate(string propertyName)
    {
        string error = null;
    	switch (propertyName)
    	{
    		case "Age":
                if (_age< 10 || _age > 100)
                    error = "The age must be between 10 and 100";
        }
    	
    	return error;
    }
