    public void MyMethod()
    {
    	// get records with the id 4
    	var myList = GetMyList(4);
    	
    	// get the property called Column1 for each one of those records and add them to this list (for demonstration)
    	var listOfColumn1 = new List<string>(); // lets assume that column holds a string
    	foreach(var thing in myList)
    	{
    		listOfColumn1.Add(thing);
    	}
    	
    	// or in a more linq-ish way
    	listOfColumn1 = myList.Select(record => record.Column1).ToList();
    	
    }
    
    public List<MyRecord> GetMyList(int thisId)
    {
    	// you're actually querying the table for records which will return an entity that
    	// fits that record rather. So you're not retrieving a list of tables, you're retrieving a 
    	// list of records from that table where the foreign key = x. i.e. a list of MyRecord
    	return MyEntities.MyTable.Where(c => c.ForeignKey == thisId).ToList();
    }
