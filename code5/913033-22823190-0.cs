    public bool add_Student(string firstname, string lastname)
    {
    	//Requires code to get the new ID, 
    	//unless your ObjectSet classes creates the ID automatically.
    	int newStudentID = 1; 
    	
    	var s = new StudentObject() 
    	{
    		id = newStudentID, //may not need to be here
    		FirstName = firstname,
    		LastName = lastname
    	};
    	
    	_stu.Add(s)
    	return true;
    }
