    class StudentViewModel
    {
        private Student _myStudent = new Student();
    
    	public string Name
    	{
    		get { return _myStudent.Name ; }
    		set
    		{
    			if (value != _myStudent.Name )
    			{
    				_myStudent.Name = value;
    				OnPropertyChanged("Name");                       
    			}
    		}
    	}
    }
