    private static IEnumerable<EmailJob> GetJobFromDB()
    {
    	var list = new List<EmailJob>();
    
    	if (MockDB.Any())
    		list.Add(MockDB.Dequeue());
    
    	return list;
    }
