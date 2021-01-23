    public string GetNewIdValue()
    {
    	// Get the counter value
    	int counter = getCounterFromDatabase();
    	
    	// Format the new id value
    	var value = String.Format("{0}-Eng-{1}", DateTime.Now.Year, counter)
    	return value;
    }
