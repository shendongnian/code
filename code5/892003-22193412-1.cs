    List<string> myList = new List<string>();
    
    myList.Add("Table1_Field1");
    myList.Add("Table1_Field2");
    myList.Add("Table1_Field3");
    myList.Add("Table2_Field4");
    myList.Add("Table2_Field4");
    myList.Add("Table2_Field4");
    
    List<string> resultList = myList.FindAll(MyFunc);
    private static bool MyFunc(string s)
    {
    
    	// AndAlso prevents evaluation of the second Boolean
    	// expression if the string is so short that an error
    	// would occur.
    	if (s.Contains("Table1")) {
    		return true;
    	} else {
    		return false;
    	}
    }
